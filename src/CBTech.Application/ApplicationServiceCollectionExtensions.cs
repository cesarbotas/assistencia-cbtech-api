using FluentValidation;
using CBTech.Application.UseCases.V1.Auth.GetCurrentUser;
using CBTech.Application.UseCases.V1.Auth.Login;
using CBTech.Application.UseCases.V1.Auth.Logout;
using CBTech.Application.UseCases.V1.Auth.LogoutAll;
using CBTech.Application.UseCases.V1.Auth.RefreshToken;
using CBTech.Application.UseCases.V1.Auth.RegisterUser;
using CBTech.Application.UseCases.V1.Enderecos.BuscarEnderecoPorCep;
using CBTech.Application.UseCases.V1.Roles.CreateRole;
using CBTech.Application.UseCases.V1.Roles.DeleteRole;
using CBTech.Application.UseCases.V1.Roles.GetRoleById;
using CBTech.Application.UseCases.V1.Roles.ListRoles;
using CBTech.Application.UseCases.V1.Roles.SetRolePermissions;
using CBTech.Application.UseCases.V1.Roles.UpdateRole;
using CBTech.Application.UseCases.V1.Permissions.CreatePermission;
using CBTech.Application.UseCases.V1.Permissions.DeletePermission;
using CBTech.Application.UseCases.V1.Permissions.GetPermissionById;
using CBTech.Application.UseCases.V1.Permissions.ListPermissions;
using CBTech.Application.UseCases.V1.Permissions.UpdatePermission;
using CBTech.Application.UseCases.V1.Usuarios.CreateUsuario;
using CBTech.Application.UseCases.V1.Usuarios.DeleteUsuario;
using CBTech.Application.UseCases.V1.Usuarios.GetUsuarioById;
using CBTech.Application.UseCases.V1.Usuarios.ListUsuarios;
using CBTech.Application.UseCases.V1.Usuarios.SetUsuarioAtivo;
using CBTech.Application.UseCases.V1.Usuarios.SetUsuarioRoles;
using Microsoft.Extensions.DependencyInjection;

namespace CBTech.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<LoginValidator>();

        services.AddScoped<ILoginHandler, LoginHandler>();
        services.AddScoped<IRegisterUserHandler, RegisterUserHandler>();
        services.AddScoped<IGetCurrentUserHandler, GetCurrentUserHandler>();
        services.AddScoped<IRefreshTokenHandler, RefreshTokenHandler>();
        services.AddScoped<ILogoutHandler, LogoutHandler>();
        services.AddScoped<ILogoutAllHandler, LogoutAllHandler>();

        services.AddScoped<IBuscarEnderecoPorCepHandler, BuscarEnderecoPorCepHandler>();

        services.AddScoped<IListRolesHandler, ListRolesHandler>();
        services.AddScoped<IGetRoleByIdHandler, GetRoleByIdHandler>();
        services.AddScoped<ICreateRoleHandler, CreateRoleHandler>();
        services.AddScoped<IUpdateRoleHandler, UpdateRoleHandler>();
        services.AddScoped<IDeleteRoleHandler, DeleteRoleHandler>();
        services.AddScoped<ISetRolePermissionsHandler, SetRolePermissionsHandler>();

        services.AddScoped<IListPermissionsHandler, ListPermissionsHandler>();
        services.AddScoped<IGetPermissionByIdHandler, GetPermissionByIdHandler>();
        services.AddScoped<ICreatePermissionHandler, CreatePermissionHandler>();
        services.AddScoped<IUpdatePermissionHandler, UpdatePermissionHandler>();
        services.AddScoped<IDeletePermissionHandler, DeletePermissionHandler>();

        services.AddScoped<IListUsuariosHandler, ListUsuariosHandler>();
        services.AddScoped<IGetUsuarioByIdHandler, GetUsuarioByIdHandler>();
        services.AddScoped<ICreateUsuarioHandler, CreateUsuarioHandler>();
        services.AddScoped<ISetUsuarioRolesHandler, SetUsuarioRolesHandler>();
        services.AddScoped<ISetUsuarioAtivoHandler, SetUsuarioAtivoHandler>();
        services.AddScoped<IDeleteUsuarioHandler, DeleteUsuarioHandler>();

        return services;
    }
}
