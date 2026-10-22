using ChallengeHAPSA.Domain.Common.Enums;
using ChallengeHAPSA.Domain.Common.Extensions;

namespace ChallengeHAPSA.Domain.Common
{
    public class Result
    {
        public ErrorOutputDTO? Error { get; set; }

        public bool IsSuccess => this.Error == null;
        public bool IsFailure => !this.IsSuccess;

        protected Result()
        {
            
        }

        public static Result Success()
        {
            return new()
            {
                Error = null
            };
        }

        public static Result UnknownError()
        {
            return new()
            {
                Error = new(ErrorCodes.UNKNOWN_ERROR)
            };
        }

        public static Result Failure(ErrorCodes code)
        {
            return new()
            {
                Error = new(code)
            };
        }

        public static Result Failure(ErrorOutputDTO error)
        {
            return new()
            {
                Error = error
            };
        }

        // operators para tirar return ErrorCodes.Algo en firmas del estilo Result Metodo()
        // en vez de return Result.Failure(ErrorCodes.Algo), para que sea un poco más limpio y rápido de escribir
        public static implicit operator Result(ErrorCodes code) => Failure(code);
        public static implicit operator Result(ErrorOutputDTO error) => Failure(error);
    }

    public class Result<T> : Result
    {
        public T? Value { get; set; }

        public static Result<T> Success(T value)
        {
            return new()
            {
                Value = value,
                Error = null
            };
        }

        new public static Result<T> Failure(ErrorCodes code)
        {
            return new()
            {
                Value = default,
                Error = new(code)
            };
        }

        new public static Result<T> Failure(ErrorOutputDTO error)
        {
            return new()
            {
                Error = error
            };
        }

        // operators para tirar return ErrorCodes.Algo / return new T() en firmas del estilo Result<T> Metodo()
        // en vez de return Result<T>.Failure(ErrorCodes.Algo) / Result<T>.Success(tValue), para que sea un poco más limpio y rápido de escribir
        public static implicit operator Result<T>(T value) => Success(value);
        public static implicit operator Result<T>(ErrorCodes code) => Failure(code);
        public static implicit operator Result<T>(ErrorOutputDTO error) => Failure(error);
    }

    public class ErrorOutputDTO
    {
        public ErrorCodes Code { get; set; }

        /// <summary>
        /// Breve descripcion del error, solo para tener una referencia rapida
        /// </summary>
        public string Description => this.Code.GetDisplayName();

        public ErrorOutputDTO()
        {

        }

        public ErrorOutputDTO(ErrorCodes code)
        {
            this.Code = code;
        }
    }
}
