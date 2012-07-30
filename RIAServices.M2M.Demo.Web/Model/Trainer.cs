﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RIAServices.M2M.Demo.Web.Model
{
    public class Trainer
    {
        #region Constructors and Destructors

        public Trainer()
        {
            Dogs = new Collection<Dog>();
        }

        #endregion

        #region Public Properties

        public ICollection<DogTrainer> DogTrainers
        {
            get { return Dogs.ToLinkTable<Dog, Trainer, DogTrainer>(this); }
        }

        public virtual ICollection<Dog> Dogs { get; set; }

        public string Name { get; set; }

        public int TrainerId { get; set; }

        #endregion
    }
}