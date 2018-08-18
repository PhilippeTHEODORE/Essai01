using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;

namespace Mdt10.Metier.DataInterfaces
{
    public interface ITypeDocumentDaoEntite : IDaoEntite<TypeDocument, int> { }

    public interface IMediaDaoEntite : IDaoEntite<Media, int> { }

    public interface IGenreDaoEntite : IDaoEntite<Genre, int> { }

    public interface IExemplaireDaoEntite : IDaoEntite<Exemplaire, int> { }

    public interface IMotCleDaoEntite : IDaoEntite<MotCle, int> { }

    public interface IDocumentDaoEntite : IDaoEntite<Document, int> { }

    public interface IDocumentMotCleDaoEntite : IDaoEntite<DocumentMotCle, int> { }

    public interface IRevueDaoEntite : IDaoEntite<Revue, int> { }

    public interface IPeriodiciteDaoEntite : IDaoEntite<Periodicite, int> { }

    public interface IPeriodiqueDaoEntite : IDaoEntite<Periodique, int> { }

    public interface ILivreDaoEntite : IDaoEntite<Livre, int> { }

    public interface IAudioDaoEntite : IDaoEntite<Audio, int> { }

    public interface IVideoDaoEntite : IDaoEntite<Video, int> { }

    public interface IBandeDessinneeDaoEntite : IDaoEntite<BandeDessinnee, int> { }

    public interface IUtilisateurDaoEntite : IDaoEntite<Utilisateur, int> { }


}
