﻿namespace BlogSystem.Web.Infrastructure.ActionResults.Contracts
{
    public interface IActionHandler<T>
    {
        void Handle(T action);
    }
}
