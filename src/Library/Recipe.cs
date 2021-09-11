//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Text;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void CreateRecipe()
        {
            StringBuilder sb = new StringBuilder($"Receta de {this.FinalProduct.Description}:\n");
            foreach (Step step in this.steps)
            {
                sb.Append($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}\n");
            }
            ConsolePrinter.ConsolePrintRecipe(sb);
            //Se cambio el metodo"PrintRecipe()"por el metodo "CreateRecipe()" 
            //ya que si le otorgaba la responsabilidad de imprimir a la clase Recipe esta tendria mas
            // de una razon de cambio e incumpliria con el SRP
            //Para solucionar esto se creo la clase ConsolePrinter y el metodo "ConsolePrintRecipe()" 
            //cumpliendo asi con el SRP ya que la unica razon de cambio seria que se quiera imprimir 
            //con un formato diferente y si se quiere añadir una nueva forma de imprimir se deberia 
            //crear una clase nueva para esa nueva responsabilidad
        }
    }
}