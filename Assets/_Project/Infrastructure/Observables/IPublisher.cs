﻿namespace _Project.Infrastructure.Observables
{
    public interface IPublisher<TSubject>
    {
        TSubject Subject { get; set; }
        event System.Action<TSubject> OnChange;
    }
}