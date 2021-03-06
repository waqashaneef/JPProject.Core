using JPProject.Admin.Domain.Commands.Clients;

namespace JPProject.Admin.Domain.Validations.Client
{
    public class SaveClientSecretCommandValidation : ClientSecretValidation<SaveClientSecretCommand>
    {
        public SaveClientSecretCommandValidation()
        {
            ValidateClientId();
            ValidateType();
            ValidateValue();
            ValidateHashType();

        }
    }
}