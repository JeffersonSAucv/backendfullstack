﻿using System;
using System.Collections.Generic;

namespace CleanArchitecture.Infraestructure.Data.Context;

public partial class User
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? DocumentNumber { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Password { get; set; }

    public string? Token { get; set; }
}
