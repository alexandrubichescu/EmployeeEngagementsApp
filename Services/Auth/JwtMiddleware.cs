﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Repository.Interfaces;
using Services.Interfaces;

namespace Services.Auth;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IUserRepository userService, IJwtUtils jwtUtils)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var userId = jwtUtils.ValidateJwtToken(token!);
        if (userId != null)
        {
            // attach user to context on successful jwt validation
            var user = await userService.GetUserByIdAsync(userId.Value);
            context.Items["User"] = user;
        }

        await _next(context);
    }
}