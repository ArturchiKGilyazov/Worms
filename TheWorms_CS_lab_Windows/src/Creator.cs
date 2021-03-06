using System;
using System.Text.RegularExpressions;
using TheWorms_CS_lab_Windows.environment;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows
{
    public class Creator
    {
        private readonly FoodService _foodService;
        private readonly IntellectualService _intellectualService;
        private readonly NameService _nameService;
        private readonly ReportService _reportService;
        private readonly DirectionService _directionService;
        private readonly NegotiatingService _negotiatingService;
        
        private readonly LandSpace _landSpace;
        private readonly Time _time;
        
        private const string Name = "Worms God";

        public Creator(
            FoodService foodService,
            IntellectualService intellectualService,
            NameService nameService,
            ReportService reportService,
            DirectionService directionService,
            NegotiatingService negotiatingService
        ) {
            _foodService = foodService;
            _nameService = nameService;
            _reportService = reportService;
            _directionService = directionService;
            _negotiatingService = negotiatingService;
            _intellectualService = intellectualService;
            _landSpace = CreateWorld();
            _time = CreateTime();
            CreateLife();
        }
        
        public void Create()
        {
            RunTime();
        }

        private LandSpace CreateWorld()
        {
            return new LandSpace(_foodService, _nameService, _directionService, _intellectualService);
        }

        private void CreateLife()
        {
            Regex sizeRegex = new Regex("\\d+");
            string usersText = _negotiatingService.Talk(Name, "enter the worms count", sizeRegex, "1");
            int wormsCount = Int32.Parse(usersText);
            _landSpace.CreateWorms(wormsCount);
        }

        private Time CreateTime()
        {
            return new Time(_landSpace, _reportService);
        }

        private void RunTime()
        {
            _time.Run();
        }
    }
}