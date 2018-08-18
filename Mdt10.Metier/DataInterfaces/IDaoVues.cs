using Mdt10.Metier.Vues;
using Mdt10.Metier.Entites;
using System.Collections.Generic;

namespace Mdt10.Metier.DataInterfaces
{
    public interface ITypeDocumentGridDao : IDaoVue<TypeDocumentGrid> { }
    public interface ITypeDocumentComboDao : IDaoVue<TypeDocumentCombo> { }

    // Objet Periodicite
    public interface IPeriodiciteGridDao : IDaoVue<PeriodiciteGrid> { }
    public interface IPeriodiciteComboDao : IDaoVue<PeriodiciteCombo> { }
    
    public interface IMediaVueDao : IDaoVue<MediaGrid> { }

    // Objet Revue
    public interface IRevueGridDao : IDaoVue<RevueGrid> { }
    public interface IRevueComboDao : IDaoVue<RevueCombo> { }

    public interface IAudioVueDao : IDaoVue<AudioGrid> { }

    // Objet Genre
    public interface IGenreGridDao : IDaoVue<GenreGrid> { }
    public interface IGenreComboDao : IDaoVue<GenreCombo> { }


    public interface IExemplaireGridDao : IDaoVue<ExemplaireGrid> { }

    // Objet Livre
    public interface ILivreGridDao : IDaoVue<LivreGrid> { }

    // Objet MotCle
    public interface IMotCleVueDao : IDaoVue<MotCleGrid> { }

    // Objet DocumentMotCle
    public interface IDocumentMotCleVueDao : IDaoVue<DocumentMotCleGrid> { }
}
