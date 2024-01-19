﻿using Coravel;
using Coravel.Events.Interfaces;
using TransferBase.Application.Events;
using TransferBase.Application.Events.Listeners;

namespace TransferBase.Application.Startup
{
    public static class Events
    {
        public static IServiceProvider RegisterEvents(this IServiceProvider services)
        {
            IEventRegistration registration = services.ConfigureEvents();

            // add events and listeners here
            registration
                .Register<UserCreated>()
                .Subscribe<EmailNewUser>();

            return services;
        }
    }
}