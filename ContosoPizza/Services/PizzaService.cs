﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public static class PizzaService
    {
        private static List<Pizza> Pizzas { get; }
        private static int nextId = 3;

        static PizzaService()
        {
            // Set default in-memory data cache to these 3 pizzas.
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true },
                new Pizza { Id = 3, Name = "Meatlovers", IsGlutenFree = false }
            };
        }

        public static List<Pizza> GetAll()
        {
            return Pizzas;
        }

        public static Pizza Get(int id)
        {
            return Pizzas.FirstOrDefault(p => p.Id == id);
        }

        public static void Add(Pizza pizza)
        {
            pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if (pizza is null) { return; }

            Pizzas.Remove(pizza);
        }

        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1) { return; }

            Pizzas[index] = pizza;
        }
    }
}