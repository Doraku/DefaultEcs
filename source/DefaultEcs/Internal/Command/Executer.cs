using System.Collections.Generic;

namespace DefaultEcs.Internal.Command
{
    internal static class Executer
    {
        public static unsafe void Execute(byte[] memory, int commandLength, List<object> objects)
        {
            fixed (byte* memoryP = memory)
            {
                byte* commands = memoryP;
                while (commandLength > 0)
                {
                    int commandSize = 0;

                    switch (*(CommandType*)commands)
                    {
                        case CommandType.Entity:
                            commandSize = sizeof(EntityCommand);
                            break;

                        case CommandType.CreateEntity:
                            EntityCommand* command = (EntityCommand*)commands;
                            command->Entity = command->Entity.World.CreateEntity();
                            commandSize = sizeof(EntityCommand);
                            break;

                        case CommandType.WorldSet:
                            WorldCommand* worldCommand = (WorldCommand*)commands;
                            commandSize = sizeof(WorldCommand);
                            commandSize += ComponentCommands.GetCommand(worldCommand->ComponentIndex).Set(World.Worlds[worldCommand->WorldId], objects, commands + sizeof(WorldCommand));
                            break;

                        case CommandType.WorldRemove:
                            worldCommand = (WorldCommand*)commands;
                            ComponentCommands.GetCommand(worldCommand->ComponentIndex).Remove(World.Worlds[worldCommand->WorldId]);
                            commandSize = sizeof(WorldCommand);
                            break;

                        case CommandType.Enable:
                            ((Entity*)(memoryP + ((EntityOffsetCommand*)commands)->EntityOffset))->Enable();
                            commandSize = sizeof(EntityOffsetCommand);
                            break;

                        case CommandType.Disable:
                            ((Entity*)(memoryP + ((EntityOffsetCommand*)commands)->EntityOffset))->Disable();
                            commandSize = sizeof(EntityOffsetCommand);
                            break;

                        case CommandType.EnableT:
                            EntityOffsetComponentCommand* componentCommand = (EntityOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand(componentCommand->ComponentIndex).Enable(*(Entity*)(memoryP + componentCommand->EntityOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.DisableT:
                            componentCommand = (EntityOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand(componentCommand->ComponentIndex).Disable(*(Entity*)(memoryP + componentCommand->EntityOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.Set:
                            componentCommand = (EntityOffsetComponentCommand*)commands;
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            commandSize += ComponentCommands.GetCommand(componentCommand->ComponentIndex).Set(*(Entity*)(memoryP + componentCommand->EntityOffset), objects, commands + sizeof(EntityOffsetComponentCommand));
                            break;

                        case CommandType.SetSameAs:
                            EntityReferenceOffsetComponentCommand* entityReferenceComponentCommand = (EntityReferenceOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand(entityReferenceComponentCommand->ComponentIndex).SetSameAs(
                                *(Entity*)(memoryP + entityReferenceComponentCommand->EntityOffset),
                                *(Entity*)(memoryP + entityReferenceComponentCommand->ReferenceOffset));
                            commandSize = sizeof(EntityReferenceOffsetComponentCommand);
                            break;

                        case CommandType.SetSameAsWorld:
                            componentCommand = (EntityOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand(componentCommand->ComponentIndex).SetSameAsWorld(*(Entity*)(memoryP + componentCommand->EntityOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.Remove:
                            componentCommand = (EntityOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand(componentCommand->ComponentIndex).Remove(*(Entity*)(memoryP + componentCommand->EntityOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.NotifyChanged:
                            componentCommand = (EntityOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand(componentCommand->ComponentIndex).NotifyChanged(*(Entity*)(memoryP + componentCommand->EntityOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.Clone:
                            CloneCommand* cloneCommand = (CloneCommand*)commands;
                            ((ComponentCloner)objects[cloneCommand->ClonerIndex]).Clone(*(Entity*)(memoryP + cloneCommand->SourceOffset), *(Entity*)(memoryP + cloneCommand->TargetOffset));
                            commandSize = sizeof(CloneCommand);
                            break;

                        case CommandType.Dispose:
                            ((Entity*)(memoryP + ((EntityOffsetCommand*)commands)->EntityOffset))->Dispose();
                            commandSize = sizeof(EntityOffsetCommand);
                            break;
                    }

                    commands += commandSize;
                    commandLength -= commandSize;
                }
            }
        }
    }
}
