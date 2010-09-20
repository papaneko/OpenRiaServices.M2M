﻿


// M2M4RiaShared.ttinclude has been located and loaded.


// Instruct compiler not to warn about usage of obsolete members, because using them is intended.
#pragma warning disable 618

#region Domain Context

namespace ClientTests.Web
{
    using System.ServiceModel.DomainServices.Client;
    using ClientTests.Web;

    public partial class M2M4RiaTestContext
    {
        partial void OnCreated()
        {
            // Install handlers that set/reset EntitySet properties of link table entities when they are
            // added/removed from the domain context's entity sets. This is only needed as long as RIA
            // doesn't provide access from an Entity to its EntitySet.
            EntitySet< AnimalVet > AnimalVetEntitySet = EntityContainer.GetEntitySet< AnimalVet>();
            AnimalVetEntitySet.EntityAdded += (sender, args) => args.Entity.EntitySet = AnimalVetEntitySet;
            AnimalVetEntitySet.EntityRemoved += (sender, args) => args.Entity.EntitySet = null;

            EntitySet< DogFireHydrant > DogFireHydrantEntitySet = EntityContainer.GetEntitySet< DogFireHydrant>();
            DogFireHydrantEntitySet.EntityAdded += (sender, args) => args.Entity.EntitySet = DogFireHydrantEntitySet;
            DogFireHydrantEntitySet.EntityRemoved += (sender, args) => args.Entity.EntitySet = null;

            EntitySet< DogTrainer > DogTrainerEntitySet = EntityContainer.GetEntitySet< DogTrainer>();
            DogTrainerEntitySet.EntityAdded += (sender, args) => args.Entity.EntitySet = DogTrainerEntitySet;
            DogTrainerEntitySet.EntityRemoved += (sender, args) => args.Entity.EntitySet = null;

        }
    }
}

#endregion

namespace ClientTests.Web
{
    #region Entities

    using System;
    using System.ServiceModel.DomainServices.Client;

    using M2M4Ria;

    /// <summary>
    /// This class provides access to the entity's entity set. This is only needed as long as RIA
    /// doesn't provide this access it self.
    /// </summary>
    public partial class AnimalVet
    {
        /// <summary>
        /// Gets or sets the EntitySet the link table entity is contained in. It is set by the domain context
        /// when the link entity is added to an entity set, and reset to null when it is removed from an entity set.
        /// </summary>
        [Obsolete("This property is only intended for use by the M2M4Ria solution.")]
        public EntitySet<AnimalVet> EntitySet{ get; set; }
    }
    /// <summary>
    /// This class provides access to the entity's entity set. This is only needed as long as RIA
    /// doesn't provide this access it self.
    /// </summary>
    public partial class DogFireHydrant
    {
        /// <summary>
        /// Gets or sets the EntitySet the link table entity is contained in. It is set by the domain context
        /// when the link entity is added to an entity set, and reset to null when it is removed from an entity set.
        /// </summary>
        [Obsolete("This property is only intended for use by the M2M4Ria solution.")]
        public EntitySet<DogFireHydrant> EntitySet{ get; set; }
    }
    /// <summary>
    /// This class provides access to the entity's entity set. This is only needed as long as RIA
    /// doesn't provide this access it self.
    /// </summary>
    public partial class DogTrainer
    {
        /// <summary>
        /// Gets or sets the EntitySet the link table entity is contained in. It is set by the domain context
        /// when the link entity is added to an entity set, and reset to null when it is removed from an entity set.
        /// </summary>
        [Obsolete("This property is only intended for use by the M2M4Ria solution.")]
        public EntitySet<DogTrainer> EntitySet{ get; set; }
    }
    public partial class Animal
    {
        //
        // Code relating to the managing of the 'AnimalVet' association from 'Animal' to 'Vet'
        //
        private IEntityCollection<Vet> _Vets;

        public IEntityCollection<Vet> Vets
        {
            get
            {
                if(_Vets == null)
                {
                    _Vets = new EntityCollection<AnimalVet, Vet>(this.AnimalVetToVetSet, r => r.Vet, (r, t2) => r.Vet = t2, r => r.Animal = this, RemoveFromAnimalVetToVetSet);
                }
                return _Vets;
            }
        }

        private void RemoveFromAnimalVetToVetSet(AnimalVet r)
        {
            if(r.EntitySet == null)
            {
                this.AnimalVetToVetSet.Remove(r);
            }
            else
            {
                r.EntitySet.Remove(r);
            }
        }
    }
    public partial class Vet
    {
        //
        // Code relating to the managing of the 'AnimalVet' association from 'Vet' to 'Animal'
        //
        private IEntityCollection<Animal> _Animals;

        public IEntityCollection<Animal> Animals
        {
            get
            {
                if(_Animals == null)
                {
                    _Animals = new EntityCollection<AnimalVet, Animal>(this.AnimalVetToAnimalSet, r => r.Animal, (r, t2) => r.Animal = t2, r => r.Vet = this, RemoveFromAnimalVetToAnimalSet);
                }
                return _Animals;
            }
        }

        private void RemoveFromAnimalVetToAnimalSet(AnimalVet r)
        {
            if(r.EntitySet == null)
            {
                this.AnimalVetToAnimalSet.Remove(r);
            }
            else
            {
                r.EntitySet.Remove(r);
            }
        }
    }
    public partial class FireHydrant
    {
    }
    public partial class Trainer
    {
        //
        // Code relating to the managing of the 'DogTrainer' association from 'Trainer' to 'Dog'
        //
        private IEntityCollection<Dog> _Dogs;

        public IEntityCollection<Dog> Dogs
        {
            get
            {
                if(_Dogs == null)
                {
                    _Dogs = new EntityCollection<DogTrainer, Dog>(this.DogTrainerToDogSet, r => r.Dog, (r, t2) => r.Dog = t2, r => r.Trainer = this, RemoveFromDogTrainerToDogSet);
                }
                return _Dogs;
            }
        }

        private void RemoveFromDogTrainerToDogSet(DogTrainer r)
        {
            if(r.EntitySet == null)
            {
                this.DogTrainerToDogSet.Remove(r);
            }
            else
            {
                r.EntitySet.Remove(r);
            }
        }
    }
    public partial class Food
    {
    }
    public partial class Dog
    {
        //
        // Code relating to the managing of the 'DogFireHydrant' association from 'Dog' to 'FireHydrant'
        //
        private IEntityCollection<FireHydrant> _FireHydrants;

        public IEntityCollection<FireHydrant> FireHydrants
        {
            get
            {
                if(_FireHydrants == null)
                {
                    _FireHydrants = new EntityCollection<DogFireHydrant, FireHydrant>(this.DogFireHydrantToFireHydrantSet, r => r.FireHydrant, (r, t2) => r.FireHydrant = t2, r => r.Dog = this, RemoveFromDogFireHydrantToFireHydrantSet);
                }
                return _FireHydrants;
            }
        }

        private void RemoveFromDogFireHydrantToFireHydrantSet(DogFireHydrant r)
        {
            if(r.EntitySet == null)
            {
                this.DogFireHydrantToFireHydrantSet.Remove(r);
            }
            else
            {
                r.EntitySet.Remove(r);
            }
        }
        //
        // Code relating to the managing of the 'DogTrainer' association from 'Dog' to 'Trainer'
        //
        private IEntityCollection<Trainer> _Trainers;

        public IEntityCollection<Trainer> Trainers
        {
            get
            {
                if(_Trainers == null)
                {
                    _Trainers = new EntityCollection<DogTrainer, Trainer>(this.DogTrainerToTrainerSet, r => r.Trainer, (r, t2) => r.Trainer = t2, r => r.Dog = this, RemoveFromDogTrainerToTrainerSet);
                }
                return _Trainers;
            }
        }

        private void RemoveFromDogTrainerToTrainerSet(DogTrainer r)
        {
            if(r.EntitySet == null)
            {
                this.DogTrainerToTrainerSet.Remove(r);
            }
            else
            {
                r.EntitySet.Remove(r);
            }
        }
    }
    #endregion

    #region EntityCollection

    namespace M2M4Ria
    {
        using System;
        using System.Collections;
        using System.Collections.Generic;
        using System.Collections.Specialized;
        using System.ComponentModel;
        using System.Linq;
        using System.ServiceModel.DomainServices.Client;

        /// <summary>
        /// Defines methods for manipulation a generic EntityCollection
        /// </summary>
        /// <typeparam name="TEntity">The type of the elements in the collection</typeparam>
        public interface IEntityCollection<TEntity> : IEnumerable<TEntity>, IEnumerable, INotifyCollectionChanged, INotifyPropertyChanged
        {
            /// <summary>
            /// Gets the current count of entities in this collection
            /// </summary>
            int Count { get; }
            /// <summary>
            /// Event raised whenever an System.ServiceModel.DomainServices.Client.Entity
            /// is added to this collection
            /// </summary>
            event EventHandler<EntityCollectionChangedEventArgs<TEntity>> EntityAdded;
            /// <summary>
            /// Event raised whenever an System.ServiceModel.DomainServices.Client.Entity
            /// is removed from this collection
            /// </summary>
            event EventHandler<EntityCollectionChangedEventArgs<TEntity>> EntityRemoved;
            /// <summary>
            /// Add the specified entity to this collection. If the entity is unattached,
            /// it will be added to its System.ServiceModel.DomainServices.Client.EntitySet
            /// automatically.
            /// </summary>
            /// <param name="entity"> The entity to add</param>
            void Add(TEntity entity);
            /// <summary>
            /// Remove the specified entity from this collection.
            /// </summary>
            /// <param name="entity">The entity to remove</param>
            void Remove(TEntity entity);
        }

        /// <summary>
        /// M2M-specific entity collection class. It vorms a view on the underlying jointable collection.
        /// </summary>
        /// <typeparam name="JoinType"></typeparam>
        /// <typeparam name="TEntity"></typeparam>
        public class EntityCollection<JoinType, TEntity> : IEntityCollection<TEntity>
            where JoinType : Entity, new()
            where TEntity : Entity
        {
            EntityCollection<JoinType> collection;
            Func<JoinType, TEntity> getEntity;
            Action<JoinType, TEntity> setEntity;
            Action<JoinType> setParent;
            Action<JoinType> removeAction;
            /// <summary>
            ///
            /// </summary>
            /// <param name="collection">The collection of associations to which this collection is connected</param>
            /// <param name="getEntity">The function used to get the entity object out of a join type entity</param>
            /// <param name="setEntity">The function used to set the entity object in a join type entity</param>
            public EntityCollection(EntityCollection<JoinType> collection, Func<JoinType, TEntity> getEntity,
                Action<JoinType, TEntity> setEntity, Action<JoinType> setParent, Action<JoinType> removeAction)
            {
                this.collection = collection;
                this.getEntity = getEntity;
                this.setEntity = setEntity;
                this.setParent = setParent;
                this.removeAction = removeAction;

                collection.EntityAdded += (a, b) =>
                {
                    JoinType jt = b.Entity as JoinType;
                    if (EntityAdded != null)
                        EntityAdded(this, new EntityCollectionChangedEventArgs<TEntity>(getEntity(jt)));
                };
                collection.EntityRemoved += (a, b) =>
                {
                    JoinType jt = b.Entity as JoinType;
                    if (EntityRemoved != null)
                        EntityRemoved(this, new EntityCollectionChangedEventArgs<TEntity>(getEntity(jt)));
                };
                ((INotifyCollectionChanged)collection).CollectionChanged += (sender, e) =>
                {
                    if (CollectionChanged != null)
                        CollectionChanged(this, MakeNotifyCollectionChangedEventArgs(e));
                };
                ((INotifyPropertyChanged)collection).PropertyChanged += (sender, e) =>
                {
                    if (PropertyChanged != null)
                        PropertyChanged(this, e);
                };
            }

            /// <summary>
            /// Replaces JoinType elements in NotifyCollectionChangedEventArgs by elements of type TEntity
            /// </summary>
            /// <param name="e"></param>
            /// <returns></returns>
            private NotifyCollectionChangedEventArgs MakeNotifyCollectionChangedEventArgs(NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        {
                            TEntity entity = getEntity((JoinType)e.NewItems[0]);
                            return new NotifyCollectionChangedEventArgs(e.Action, entity ?? entityToAdd, 0);
                        }
                    case NotifyCollectionChangedAction.Remove:
                        {
                            TEntity entity = getEntity((JoinType)e.OldItems[0]);
                            return new NotifyCollectionChangedEventArgs(e.Action, entity, 0);
                        }
                    case NotifyCollectionChangedAction.Reset:
                        return new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset);
                }
                throw new Exception(String.Format("NotifyCollectionChangedAction.{0} action not supported by M2M4Ria.EntityCollection", e.Action.ToString()));
            }

            public IEnumerator<TEntity> GetEnumerator()
            {
                return collection.Select(getEntity).GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public int Count
            {
                get
                {
                    return collection.Count;
                }
            }

            TEntity entityToAdd = null;
            public void Add(TEntity entity)
            {
                entityToAdd = entity;
                JoinType joinTypeToAdd = new JoinType();
                setParent(joinTypeToAdd);
                setEntity(joinTypeToAdd, entity);
                entityToAdd = null;
            }
            /// <summary>
            /// Use remove on the entityset on the domain context, rather than this functioln
            /// There seems to be a limitation of RIA which requires that associations should be deleted on the domain context
            /// </summary>
            /// <param name="entity"></param>
            public void Remove(TEntity entity)
            {
                JoinType joinTypeToRemove = collection.SingleOrDefault(jt => getEntity(jt) == entity);
                if (joinTypeToRemove != null)
                    removeAction(joinTypeToRemove);
            }

            public event EventHandler<EntityCollectionChangedEventArgs<TEntity>> EntityAdded;
            public event EventHandler<EntityCollectionChangedEventArgs<TEntity>> EntityRemoved;
            public event NotifyCollectionChangedEventHandler CollectionChanged;
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
    #endregion
}

// Restore compiler warnings when using obsolete methods
#pragma warning restore 618
