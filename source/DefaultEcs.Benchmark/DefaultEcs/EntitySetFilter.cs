﻿using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;

namespace DefaultEcs.Benchmark.DefaultEcs
{
    [MemoryDiagnoser]
    [SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 1, targetCount: 10, invocationCount: 100)]
    public sealed class EntitySetFilter : IDisposable
    {
        private World _world;
        private EntitySet _set;
        private EntitySet _with;
        private EntitySet _without;
        private EntitySet _withEither;
        private EntitySet _withoutEither;

        [Params(100000)]
        public int EntityCount { get; set; }

        [IterationSetup]
        public void Setup()
        {
            _world = new World();
            _set = _world.GetEntities().AsSet();
            _with = _world.GetEntities().With<double>().AsSet();
            _without = _world.GetEntities().With<int>().Without<uint>().AsSet();
            _withEither = _world.GetEntities().WithEither<string>().Or<char>().AsSet();
            _withoutEither = _world.GetEntities().With<float>().WithoutEither<long>().Or<ulong>().AsSet();

            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _world.CreateEntity();

                entity.Set(1d);
                entity.Set(1);
                entity.Set('t');
                entity.Set(1f);
            }

            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                entity.Remove<double>();
                entity.Remove<int>();
                entity.Remove<char>();
                entity.Remove<float>();
            }
        }

        [IterationCleanup]
        public void Dispose()
        {
            _with.Dispose();
            _without.Dispose();
            _withEither.Dispose();
            _withoutEither.Dispose();
            _set.Dispose();
            _world.Dispose();
        }

        [Benchmark]
        public void With()
        {
            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                entity.Set(42d);
            }
        }

        [Benchmark]
        public void Without()
        {
            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                entity.Set(42);
            }
        }

        [Benchmark]
        public void WithEither()
        {
            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                entity.Set(' ');
            }
        }

        [Benchmark]
        public void WithoutEither()
        {
            foreach (ref readonly Entity entity in _set.GetEntities())
            {
                entity.Set(42f);
            }
        }
    }
}
