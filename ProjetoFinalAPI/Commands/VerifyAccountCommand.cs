using MediatR;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Commands
{
    public record VerifyAccountCommand(Account account) : IRequest<bool>;

}
