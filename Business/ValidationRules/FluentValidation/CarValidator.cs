using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.Description).MinimumLength(2).WithMessage("Araç adı en az 2 karakter uzunluğunda olmalıdır.");
            RuleFor(car => car.Description).NotEmpty();
            RuleFor(car => car.Description).NotNull();

            RuleFor(car => car.DailyPrice).NotEmpty();
            RuleFor(car => car.DailyPrice).GreaterThan(0).WithMessage("Aracın günlük fiyatı 0'dan büyük olmalıdır.");
            RuleFor(car => car.DailyPrice).GreaterThan(100).When(car => car.CarId == 1).WithMessage("1 id'li aracın günlük fiyatı 100'den büyük olmalıdır.");

            RuleFor(car => car.ModelYear).LessThan(DateTime.Now.Year);
            RuleFor(car => car.ModelYear).NotEmpty();
            
            RuleFor(car => car.BrandId).NotEmpty();
            RuleFor(car => car.BrandId).GreaterThan(0).WithMessage("Araç marka numarası (Id) en az 0 karakter uzunluğunda olmalıdır.");

            RuleFor(car => car.ColorId).NotEmpty();
            RuleFor(car => car.ColorId).GreaterThan(0).WithMessage("Araç renk numarası (Id) en az 0 karakter uzunluğunda olmalıdır.");
        }
    }
}
