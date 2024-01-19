﻿using Microsoft.AspNetCore.Components;
using TransferBase.Application.Models;

namespace TransferBase.Pages.Shared
{
    public partial class NavMenu
    {
        [CascadingParameter]
        public MainLayout? Layout { get; set; }
        private User? user => Layout?.User;
    }
}