﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Microsoft.Data.Entity;

namespace Command.Core
{

    public class OrderVisitingCards : ICommand
    {
        private EmployeeManager manager;

        public OrderVisitingCards(EmployeeManager manager)
        {
            this.manager = manager;
        }

        public void Execute()
        {
            manager.OrderVisitingCards();
        }

        public void Undo()
        {
            manager.UndoOrderVisitingCards();
        }

    }
}
