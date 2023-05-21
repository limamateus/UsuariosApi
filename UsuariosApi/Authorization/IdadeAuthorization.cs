using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuariosApi.Authorization
{
    public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
        {
            // Aqui estou pegando os dados de um claim especifico 
            var dataNascimentoClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);


            if (dataNascimentoClaim is null) return Task.CompletedTask;

            var dataNascimento =
                Convert.ToDateTime(dataNascimentoClaim.Value); // Caso ele não for nulo eu vou pegar o valor dele converte para DateTime

            var idadeUsuario =
                DateTime.Today.Year - dataNascimento.Year;

            if (dataNascimento > DateTime.Today.AddYears(-idadeUsuario))
            {
                idadeUsuario--;
            }



            if (idadeUsuario >= requirement.Idade)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;

        }
    }
}
