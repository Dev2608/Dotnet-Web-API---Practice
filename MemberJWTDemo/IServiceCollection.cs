using System;

namespace MemberJWTDemo
{
    public interface IServiceCollection
    {
        void AddControllers();
        void AddSwaggerGen(Action<object> p);
    }
}