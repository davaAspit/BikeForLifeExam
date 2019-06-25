﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BikeForLife.Dal;
using BikeForLife.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sommerland.Service;

namespace BikeForLife.Web.Pages
{
    public class RoutesModel : PageModel
    {
        [BindProperty]
        public BikeRoute BikeRoute { get; set; }
        public List<BikeRoute> BikeRoutes { get; set; } = new List<BikeRoute>();
        //public OpenWeatherMap weatherMap { get; set; } = new OpenWeatherMap();
        public IActionResult OnGet()
        {
            BikeRouteRepository bikeRouteRepository = new BikeRouteRepository();
            try
            {
                BikeRoutes = bikeRouteRepository.GetAll();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
            return Page();
        }

        public void OnPost()
        {

        }

        public string GetTempatureBasedOnCity(string city)
        {
            OpenWeatherMap weatherMap = new OpenWeatherMap();
            weatherMap.AppId = "3654de113ecd4a2bf4e4144d9403491b";
            weatherMap.City = city;
            double temp = 0.0;
            try
            {
                temp = weatherMap.GetTempature();
            }
            catch (WebException)
            {
                return "N/A";
            }
            return $"{temp}°";
        }

        public string GetWeatherIconBasedOnCity(string city)
        {
            OpenWeatherMap weatherMap = new OpenWeatherMap();
            weatherMap.AppId = "3654de113ecd4a2bf4e4144d9403491b";
            weatherMap.City = city;
            string icon;
            try
            {
                icon = weatherMap.GetWeatherIcon();
            }
            catch (WebException)
            {
                return "N/A";
            }
            return $"{icon}";
        }
    }
}