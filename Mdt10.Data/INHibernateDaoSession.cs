using System;
namespace Mdt10.Data
{
    interface INHibernateDaoSession
    {
        NHibernate.ISession GetCurrentSession();
    }
}
