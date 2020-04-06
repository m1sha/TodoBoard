using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoBoard.Core.Entities.Validators
{
  public class TodoItemValidator: AbstractValidator<TodoItem>
  {
    public TodoItemValidator()
    {
      RuleFor(r => r.Title).NotEmpty().WithMessage("Titile is empty");
      RuleFor(r => r.Status).NotEqual(TodoStatus.Unknown).WithMessage("Status is Unknown");
      RuleFor(r => r.Message).NotEmpty().WithMessage("Message is empty");
    }
  }
}
