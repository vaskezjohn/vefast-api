using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vefast_src.Domain.Exceptions.Users
{
    public class IdentityErrorException : EntityException
    {
        public IdentityErrorException(string message) 
            : base(message)
        {
        }

        public static void ThrowIdentityErrorException(IdentityError error)
        {
            switch (error.Code)
            {
                case "DuplicateUserName":
                    throw new IdentityErrorException("El usuario esta duplicado") { Code = error.Code };

                case "DefaultError":
                    throw new IdentityErrorException(error.Description) { Code = error.Code };

                case "ConcurrencyFailure":
                    throw new IdentityErrorException("Error cuando falla la concurrencia optimista") { Code = error.Code };

                case "DuplicateEmail":
                    throw new IdentityErrorException($"Email se encuentra en uso por otra persona") { Code = error.Code };
                case "DuplicateRoleName":
                    throw new IdentityErrorException("Error") { Code = error.Code };
                case "InvalidEmail":
                    throw new IdentityErrorException("Email inválido") { Code = error.Code };
                case "InvalidManagerType":
                    throw new IdentityErrorException(error.Description) { Code = error.Code };
                case "InvalidPasswordHasherCompatibilityMode":
                    throw new IdentityErrorException(error.Description) { Code = error.Code };
                case "InvalidPasswordHasherIterationCount":
                    throw new IdentityErrorException(error.Description) { Code = error.Code };
                case "InvalidRoleName":
                    throw new IdentityErrorException("Nombre del Rol es inválido") { Code = error.Code };
                case "InvalidToken":
                    throw new IdentityErrorException("Token inválido") { Code = error.Code };
                case "InvalidUserName":
                    throw new IdentityErrorException("El nombre de usuario solo puede contener letras o dígitos") { Code = error.Code };
                case "PasswordMismatch":
                    throw new IdentityErrorException("Contraseña de usuario incorrecta") { Code = error.Code };
                case "PasswordRequiresDigit":
                    throw new IdentityErrorException("Las contraseñas deben tener al menos un dígito ('0' - '9')") { Code = error.Code };
                case "PasswordRequiresLower":
                    throw new IdentityErrorException("Las contraseñas deben tener al menos una minúscula ('a' - 'z')") { Code = error.Code };
                case "PasswordRequiresNonAlphanumeric":
                    throw new IdentityErrorException("Las contraseñas deben tener al menos un carácter no alfanumérico") { Code = error.Code };
                case "PasswordRequiresUpper":
                    throw new IdentityErrorException("Las contraseñas deben tener al menos una mayúscula ('A' - 'Z')") { Code = error.Code };
                case "PasswordTooShort":
                    throw new IdentityErrorException("Las contraseñas debe ser mas larga") { Code = error.Code };
                case "UserNameNotFound":
                    throw new IdentityErrorException("El usuario no existe") { Code = error.Code };
                case "UserNotInRole":
                    throw new IdentityErrorException("El usuario no está en el rol") { Code = error.Code };
                case "EmailNotConfirmed":
                    throw new IdentityErrorException("Email no confirmado") { Code = error.Code };

                case "UserDisabled":
                    throw new IdentityErrorException("El usuario se encuentra desactivado") { Code = error.Code };

                default:
                    throw new IdentityErrorException(error.Description) { Code = error.Code };

            }

        }
    }
}
