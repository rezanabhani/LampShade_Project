using System.Collections.Generic;
using _0_Framework.Application;
using _0_Framework.Application.Sms;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ISmsService _smsService;
        private readonly IAuthHelper _authHelper;


        public AccountApplication(IFileUploader fileUploader, IAccountRepository accountRepository, IPasswordHasher passwordHasher, ISmsService smsService, IAuthHelper authHelper)
        {
            _fileUploader = fileUploader;
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _smsService = smsService;
            _authHelper = authHelper;
        }

        public OperationResult Register(RegisterAccount command)
        {
            var operation = new OperationResult();

            if (_accountRepository.Exists(x => x.Username == command.Username || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var randomNumberGenerator = new _0_Framework.Application.RandomNumberGenerator();
            command.Password = randomNumberGenerator.GenerateRandomNumber().ToString();
            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            var account = new Account(command.Fullname, command.Username, command.Password, command.Mobile, command.RoleId,
                picturePath);

            _accountRepository.Create(account);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (_accountRepository.Exists(x =>
                    (x.Username == command.Username || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed(ApplicationMessage.DuplicatedRecord);

            var path = $"profilePhotos";
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, path);
            account.Edit(command.Fullname, command.Username, command.Mobile, command.RoleId, picturePath);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessage.RecordNotFound);

            if (command.Passsword != command.RePassword)
                operation.Failed(ApplicationMessage.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Passsword);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult SendCode(Login command)
        {
            var operation = new OperationResult();
            var randomNumberGenerator = new _0_Framework.Application.RandomNumberGenerator();

            command.Password = randomNumberGenerator.GenerateRandomNumber().ToString();
            var account = _accountRepository.GetBy(command.Mobile);
            if (account == null)
                return operation.Failed(ApplicationMessage.UserNotExists);

            account.ChangePassword(command.Password);
            _accountRepository.SaveChanges();
            //_smsService.SendVerificationCodeAsync(command.Mobile, command.Password);
            
            return operation.Succedded();
        }

        public OperationResult Login(Login command)
        {
            var operation = new OperationResult();
            var account = _accountRepository.GetBy(command.Mobile);
            if (account == null)
                return operation.Failed(ApplicationMessage.UserNotExists);


            //var result = _passwordHasher.Check(account.Password, command.Password);
            //if (!result.Verified)
            //    return operation.Failed(ApplicationMessage.UserNotExists);

            //_smsService.SendVerificationCodeAsync(command.Mobile, command.Password);

            var authViewModel = new AuthViewModel(account.Id,account.RoleId,account.Fullname,account.Username,account.Mobile);
            _authHelper.Signin(authViewModel);
            return operation.Succedded();

        }

        public string GetPassword(string mobile)
        {
            var account = _accountRepository.GetBy(mobile);
            var pass = account.Password;
            return pass;
        }

        public EditAccount GetDetails(long id)
        {
          return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _accountRepository.Search(searchModel);
        }

        public void Logout()
        {
            _authHelper.SignOut();
        }
    }
}
