using System.Collections.Generic;

namespace DefaultEcs.Technical.Command
{
    internal static class Executer
    {
        public static unsafe Entity Execute(byte[] memory, int commandLength, List<object> objects, World world)
        {
            Entity lastEntity = default;

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
                            lastEntity = (*(EntityCommand*)commands).Entity = world.CreateEntity();
                            commandSize = sizeof(EntityCommand);
                            break;

                        case CommandType.Enable:
                            (*(Entity*)(memoryP + (*(EntityOffsetCommand*)commands).EntityOffset)).Enable();
                            commandSize = sizeof(EntityOffsetCommand);
                            break;

                        case CommandType.Disable:
                            (*(Entity*)(memoryP + (*(EntityOffsetCommand*)commands).EntityOffset)).Disable();
                            commandSize = sizeof(EntityOffsetCommand);
                            break;

                        case CommandType.EnableT:
                            EntityOffsetComponentCommand* componentCommand = (EntityOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand((*componentCommand).ComponentIndex).Enable(*(Entity*)(memoryP + (*componentCommand).EntityOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.DisableT:
                            componentCommand = (EntityOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand((*componentCommand).ComponentIndex).Disable(*(Entity*)(memoryP + (*componentCommand).EntityOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.Set:
                            componentCommand = (EntityOffsetComponentCommand*)commands;
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            commandSize += ComponentCommands.GetCommand((*componentCommand).ComponentIndex).Set(*(Entity*)(memoryP + (*componentCommand).EntityOffset), objects, commands + sizeof(EntityOffsetComponentCommand));
                            break;

                        case CommandType.SetSameAs:
                            EntityReferenceOffsetComponentCommand* entityReferenceComponentCommand = (EntityReferenceOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand((*entityReferenceComponentCommand).ComponentIndex).SetSameAs(
                                *(Entity*)(memoryP + (*entityReferenceComponentCommand).EntityOffset),
                                *(Entity*)(memoryP + (*entityReferenceComponentCommand).ReferenceOffset));
                            commandSize = sizeof(EntityReferenceOffsetComponentCommand);
                            break;

                        case CommandType.Remove:
                            componentCommand = (EntityOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand((*componentCommand).ComponentIndex).Remove(*(Entity*)(memoryP + (*componentCommand).EntityOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.NotifyChanged:
                            componentCommand = (EntityOffsetComponentCommand*)commands;
                            ComponentCommands.GetCommand((*componentCommand).ComponentIndex).NotifyChanged(*(Entity*)(memoryP + (*componentCommand).EntityOffset));
                            commandSize = sizeof(EntityOffsetComponentCommand);
                            break;

                        case CommandType.SetAsChildOf:
                            ChildParentOffsetCommand* childParent = (ChildParentOffsetCommand*)commands;
                            (*(Entity*)(memoryP + (*childParent).ChildOffset)).SetAsChildOf(*(Entity*)(memoryP + (*childParent).ParentOffset));
                            commandSize = sizeof(ChildParentOffsetCommand);
                            break;

                        case CommandType.RemoveFromChildrenOf:
                            childParent = (ChildParentOffsetCommand*)commands;
                            (*(Entity*)(memoryP + (*childParent).ChildOffset)).RemoveFromChildrenOf(*(Entity*)(memoryP + (*childParent).ParentOffset));
                            commandSize = sizeof(ChildParentOffsetCommand);
                            break;

                        case CommandType.Dispose:
                            (*(Entity*)(memoryP + (*(EntityOffsetCommand*)commands).EntityOffset)).Dispose();
                            commandSize = sizeof(EntityOffsetCommand);
                            break;
                    }

                    commands += commandSize;
                    commandLength -= commandSize;
                }
            }

            return lastEntity;
        }
    }
}
