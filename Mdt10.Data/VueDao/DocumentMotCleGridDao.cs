using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using NHibernate;
using Mdt10.Metier.Sorting;
using Mdt10.Metier.Enums;

namespace Mdt10.Data.VueDao
{
    public class DocumentMotCleGridDao : AbstractVueDao<DocumentMotCleGrid>, IDocumentMotCleVueDao
    {
        public DocumentMotCleGridDao(IDaoSession daoSession)
            : base(daoSession)
        {
            _idColumnName = "Id";
        }

        public override List<DocumentMotCleGrid> GetVue(Dictionary<string, string> filters)
        {

            string select = "select mc.Id as Id_Mot_Cle, mc.Mot as Mot from MotCle mc ";

            IQuery query = NHibernateSession.CreateQuery(select);
            List<DocumentMotCleGrid> _documentMotCleGrid =(List<DocumentMotCleGrid>) query.SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean<DocumentMotCleGrid>()).List<DocumentMotCleGrid>();

            select = "select dmc.Id as Id, dmc.Document.Id as Id_Document, dmc.MotCle.Id as Id_Mot_Cle from DocumentMotCle dmc ";

            string where = "";

            if (filters != null)
            {
                foreach (KeyValuePair<string, string> filter in filters)
                {
                    if (filter.Key == "IdDocument") where = "where dmc.Document.Id = : IdDocument ";
                }
            }

            query = NHibernateSession.CreateQuery(select + where);

            if (filters != null)
                foreach (KeyValuePair<string, string> filter in filters) query.SetParameter(filter.Key, filter.Value);


            List<MotCleDocument> _documentMotCle =(List<MotCleDocument>) query.SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean<MotCleDocument>()).List<MotCleDocument>();

            if (_documentMotCle.Count > 0)
            {
                int _count = 0;
                foreach (DocumentMotCleGrid dmc in _documentMotCleGrid)
                {
                    if (_count == _documentMotCle.Count) break;

                    foreach (MotCleDocument mcd in _documentMotCle)
                    {
                        if (_count == _documentMotCle.Count) break;

                        if (mcd.Id_Mot_Cle == dmc.Id_Mot_Cle)
                        {
                            _count++;
                            dmc.Checked = true;
                            dmc.Id = mcd.Id;
                            dmc.Id_Document = mcd.Id_Document;
                            break;
                            //if (_count == _documentMotCle.Count) break;
                        }
                    }
                }
            }
            return _documentMotCleGrid;
        }

        private class MotCleDocument
        {
            public int Id { get; set; }
            public int Id_Document { get; set; }
            public int Id_Mot_Cle { get; set; }
        }

        private class MotCle
        {
            public int Id { get; set; }
            public string Mot { get; set; }
        }

        protected override string QueryBuilder(Dictionary<string, string> filters)
        {

            //string select = "select dmcs.Id as Id, mc.Id as IdMotCle, doc.Id as IdDocument, mc.Mot as Mot from MotCle mc left join mc.DocumentMotCles dmcs left join dmcs.Document doc ";


            //string select = "select dmc.Id as Id, mc.Id as IdMotCle, dmc.Document.Id as IdDocument, mc.Mot as Mot from DocumentMotCle dmc right outer join dmc.MotCle mc ";
            string selectDmc = "select dmc.Mocle.Id as Id from DocumentMotCle dmc ";


            string where = "";

            if (filters != null)
            {
                foreach (KeyValuePair<string, string> filter in filters)
                {
                    if (filter.Key == "IdDocument") where = "where dmc.Document.Id = : IdDocument or dmc.Document.Id is null ";
                }
            }
            string order = "order by mc.Mot ";
            return selectDmc + where + order;
        }
        //return "select mc.Id as IdMotCle, dmc.Id as IdDocument, mc.Mot as Mot from MotCle mc left outer join DocumentMotCle dmc order by mc.Mot";     


        //public override List<DocumentMotCleGrid> Sort(List<DocumentMotCleGrid> list, List<SortingProperty<DocumentMotCleGrid>> sortingProperties)
        //{
        //    return list;
        //}


    }
}
