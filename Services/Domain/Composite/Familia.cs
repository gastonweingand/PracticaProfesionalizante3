///////////////////////////////////////////////////////////
//  Familia.cs
//  Implementation of the Class Familia
//  Generated by Enterprise Architect
//  Created on:      20-abr.-2023 19:35:22
//  Original author: gasto
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Services.Domain.Composite
{

    /// <summary>
    /// This class (a) defines behaviour for components having children, (b) stores
    /// child components, and (c) implements child-related operations in the Component
    /// interface.
    /// </summary>
    public class Familia : Component
    {

        private List<Component> children = new List<Component>();

        public String NombrePerfil { get; set; }

        public Familia()
        {

        }
        /// 
        /// <param name="component"></param>
        public override void Add(Component component)
        {
            children.Add(component);
        }

        public override int CountChild()
        {
            if (children.Count == 0)
                throw new Exception("La familia no puede tener 0 elementos hijos");

            return children.Count;
        }

        /// 
        /// <param name="component"></param>
        public override void Remove(Component component)
        {
            //children.Remove(component);
            children.RemoveAll(o => o.Id == component.Id); //Linq to object
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Component> GetAll()
        {
            return children;
        }

    }//end Familia
}