using MediatR;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Commands
{
    public record AddAccountCommand(Account account) : IRequest<Account>;
   
}
