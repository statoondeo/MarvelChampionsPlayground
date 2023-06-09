﻿using System;

public sealed class LifeComponent : BaseCardComponent<ILifeComponent>, ILifeComponent
{
    public int CurrentLife
    {
        get
        {
            throw new NotImplementedException();
        }
    }
    private int _TotalLife;
    public int TotalLife
    {
        get => _TotalLife;
        private set
        {
            if (_TotalLife == value) return;
            _TotalLife = value;
            Card?.Raise<ILifeComponent>();
        }
    }
    private int _Damage;
    public int Damage
    {
        get => _Damage;
        private set
        {
            if (_Damage == value) return;
            _Damage = value;
            Card?.Raise<ILifeComponent>();
        }
    }
    private int InitialLife;
    private LifeComponent(int life) : base()
    {
        InitialLife = life;
        TotalLife = life;
        Damage = 0;
    }
    public override void Init()
    {
        TotalLife = InitialLife;
        Damage = 0;
    }

    public void TakeDamage(int damage) => Damage += damage;
    public void HealDamage(int damage) => Damage -= damage;
    public static ILifeComponent Get(int life) => new LifeComponent(life);
}
