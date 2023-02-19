using System;
using Microsoft.AspNetCore.Mvc;
using SuperHeroApi.Models;

namespace SuperHeroApi.Controllers
{
    [Route("api/[controller]")] // атрибут api/[controller]
    // визначає, що контролер повинен відповідати на HTTP-запити за допомогою автоматичного зв’язування та перевірки моделі.
    
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        // Приватний статичний список героїв List<SuperHero> = новий рядок List<SuperHero> визначає статичний список об’єктів SuperHero,
        // який представляє сховище даних для API
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "Spider Man",
                FirstName = "Peter",
                LastName = "Parker",
                Place = "New York City"
            },
            new SuperHero
            {
                Id = 2,
                Name = "Arina",
                FirstName = "Igorivna",
                LastName = "Bolychova",
                Place = "Kyiv City"
            }
        };


        [HttpGet]
        // Асинхронний метод, для отримання всіх героїв. Він повертає об’єкт ActionResult<List<SuperHero>>,
        // який інкапсулює результат операції. У цьому випадку він повертає список об’єктів SuperHero, загорнутий у результат Ok.
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        // визначає, що цей метод дії має обробляти HTTP-запити GET із параметром ідентифікатора.
        // Використовується для отримання одного героя за ідентифікатором.
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null) // якщо ідентифікатора нема 
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        // це метод дії для додавання нового героя до API.
        // Він додає наданий об’єкт героя до списку героїв і повертає список об’єктів SuperHero, загорнутий у результат Ok.
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);
            return Ok(heroes);
        }
        
        [HttpPut]
        // Загальнодоступний асинхронний рядок 
        // визначає публічний асинхронний метод під назвою UpdateHero,
        // який приймає об’єкт SuperHero як параметр і повертає ActionResult<List<SuperHero>>.
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {
            //  рядок шукає в списку героїв супергероя з тим же ідентифікатором, що й параметр запиту.
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null) // перевіряє, чи є об’єкт hero нульовим.
            // Якщо так, метод повертає неправильний код статусу HTTP запиту (400) із повідомленням про помилку «Герой не знайдено».
                return BadRequest("Hero not found.");
            
            // рядки оновлюють властивості об’єкта супергероя відповідними значеннями з об’єкта запиту.
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            
            heroes.Add(hero); // рядок додає оновлений об’єкт героя назад до списку героїв.
            return Ok(heroes); // Метод повертає код статусу HTTP 200 (OK) з оновленим списком героїв у тілі відповіді.
            
            //Таким чином, цей код визначає кінцеву точку PUT, яка дозволяє клієнтам оновлювати існуючого супергероя,
            //надсилаючи об’єкт SuperHero як тіло запиту з оновленими значеннями.
            //Метод оновлює властивості супергероя та повертає оновлений список супергероїв
        }
        
        // це метод дії для видалення героя з API.
        [HttpDelete("{id}")]
        
        // передається параметр id, який відповідає ідентифікатору героя для видалення.
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null) // якщо ідентифікатора нема 
                return BadRequest("Hero not found.");

            heroes.Remove(hero); // видаляється зі списку за допомогою методу Remove
            return Ok(heroes); // Після видалення метод повертає змінений список героїв з кодом статусу 200 OK
        }
    }
}