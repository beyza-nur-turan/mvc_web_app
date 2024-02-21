using System.Text.Json;

namespace StoreApp.Infrastructure.Extensions
{
    //extensions methodları genelde static olarak tanımlarız
    public static class SessionExtension
    {
        //static bir classın bütün ögeleri static olur. yani newleme yapmadan nesne türetmeden 
        //doğrudan ilgili sınıf adı üzerinden sınıf üyelerine erişebiliriz.
        public static void SetJson(this ISession session,string key ,object value)
        {
            session.SetString(key,JsonSerializer.Serialize(value));//value deki ilgili nesneyi string olarak sessiona kaydediyoruz diyebiliriz.

        }
        public static void SetJson<T>(this ISession session,string key,object value)
        {
            session.SetString(key,JsonSerializer.Serialize(value));
        }
        public static T? GetJson<T>(this ISession session,string key)
        {
            var data=session.GetString(key);
            return data is null 
            ? default(T)
            :JsonSerializer.Deserialize<T>(data);
        }
        
    }
}