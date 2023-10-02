using System.Threading.Tasks;

namespace _0_Framework.Application.Sms
{
    public interface ISmsService
    {
        Task<bool> SendVerificationCodeAsync(string phoneNumber, string verificationCode);
    }
}