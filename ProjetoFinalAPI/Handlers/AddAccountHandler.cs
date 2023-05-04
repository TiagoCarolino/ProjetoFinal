using MediatR;
using ProjetoFinalAPI.Commands;
using ProjetoFinalAPI.Data;
using ProjetoFinalAPI.Models;

namespace ProjetoFinalAPI.Handlers
{
    public class AddAccountHandler : IRequestHandler<AddAccountCommand, Account>
    {
        IDataContext _dataContext;

        public AddAccountHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public async Task<Account> Handle(AddAccountCommand request, CancellationToken cancellationToken)
        {
            var accounts = _dataContext.Accounts;

            if (accounts == null)
            {
                return null;
            }
            else
            {
                try
                {
                    request.account.Username = request.account.Username.ToLower();

                    if (request.account.Username != "admin")
                    {

                        var account = _dataContext.Accounts.FirstOrDefault(x => x.Username == request.account.Username);

                        if (account == null)
                            await accounts.AddAsync(request.account);
                        else
                        {
                            account.Password = request.account.Password;
                        }
                        await _dataContext.SaveChangesAsync(cancellationToken);
                    }

                    return request.account;
                }
                catch (Exception e)
                {

                    throw;
                }
            }


        }
    }
}

