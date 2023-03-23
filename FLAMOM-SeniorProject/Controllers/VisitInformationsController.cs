using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FLAMOM_SeniorProject.Data;
using FLAMOM_SeniorProject.ViewModel;
using AutoMapper;

namespace FLAMOM_SeniorProject.Controllers
{
    public class VisitInformationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VisitInformationsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

      
       

        // GET: VisitInformations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VisitInformations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VisitInformationVM visitInformation)
        {
            if (ModelState.IsValid)
            {
                //this is what gets generated to be saved to database, we need to remove these in all future forms
                //except the final page where we will submit all of the data together
                //_context.Add(visitInformationVm);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(DentalHealth), visitInformation);
            }
            return View(visitInformation);
        }

        public IActionResult DentalHealth(VisitInformationVM visitInformation)
        {
            DentalHealthVM dentalHealthVM = _mapper.Map<DentalHealthVM>(visitInformation);


            return View(dentalHealthVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DentalHealth(DentalHealthVM dentalHealth)
        {
            if (ModelState.IsValid)
            {
                //this is what gets generated to be saved to database, we need to remove these in all future forms
                //except the final page where we will submit all of the data together
                //_context.Add(visitInformationVm);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(AboutYou), dentalHealth);
            }
            return View(dentalHealth);
        }

        public IActionResult AboutYou(DentalHealthVM dentalHealth)
        {
            AboutYouVM aboutYouVM = _mapper.Map<AboutYouVM>(dentalHealth);


            return View(aboutYouVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AboutYou(AboutYouVM aboutYou)
        {
            if (ModelState.IsValid)
            {
                //this is what gets generated to be saved to database, we need to remove these in all future forms
                //except the final page where we will submit all of the data together
                //_context.Add(visitInformationVm);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(YourHousehold), aboutYou);
            }
            return View(aboutYou);
        }
        public IActionResult Confirmation(ConfirmationVM confirmationVM)
        {
            return View(confirmationVM);
        }
        public IActionResult YourHousehold(AboutYouVM aboutYou)
        {
            YourHouseholdVM yourHouseholdVM = _mapper.Map<YourHouseholdVM>(aboutYou);


            return View(yourHouseholdVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> YourHousehold(YourHouseholdVM yourHouseholdVM)
        {
            if (ModelState.IsValid)
            {
                Patient patient = new Patient()
                {
                    UniquePatientId = Patient.GenerateUniqueId(),
                    MouthPain = yourHouseholdVM.MouthPain,
                    LengthOfPain = yourHouseholdVM.LengthOfPain,
                    OverallHealth = yourHouseholdVM.OverallHealth,
                    TimeToTravel = yourHouseholdVM.TimeToTravel,
                    AttendBefore = yourHouseholdVM.AttendBefore,
                    OtherAnswer = yourHouseholdVM.OtherAnswer,
                    TeethGums = yourHouseholdVM.TeethGums,
                    MainRsn = yourHouseholdVM.MainRsn,
                    LastVisit = yourHouseholdVM.LastVisit,
                    MainRsnLstVst = yourHouseholdVM.MainRsnLstVst,
                    UsualCare = yourHouseholdVM.UsualCare,
                    Emrgncy = yourHouseholdVM.Emrgncy,
                    LastSixMnths = yourHouseholdVM.LastSixMnths,
                    GoToOffice = yourHouseholdVM.GoToOffice,
                    UsualJobs = yourHouseholdVM.UsualJobs,
                    Insurance = yourHouseholdVM.Insurance,
                    LevelOfSchool = yourHouseholdVM.LevelOfSchool,
                    ServedInMil = yourHouseholdVM.ServedInMil,
                    Hispanic = yourHouseholdVM.Hispanic,
                    JobSituation = yourHouseholdVM.JobSituation,
                    PeopleAtHome = yourHouseholdVM.PeopleAtHome,
                    FoodStamp = yourHouseholdVM.FoodStamp,
                    WicProg = yourHouseholdVM.WicProg,
                    HouseIncome = yourHouseholdVM.HouseIncome
                };
                _context.Patient.Add(patient);
                _context.SaveChanges();

                List<ReasonForVisit> reasonForVisits = new List<ReasonForVisit>();
                if (yourHouseholdVM.Cleaning)
                {
                    ReasonForVisit reasonForVisit = new ReasonForVisit
                    {
                        PatientId = patient.Id,
                        Reason = "Cleaning"
                    };
                    reasonForVisits.Add(reasonForVisit);
                }
                if (yourHouseholdVM.Filling)
                {
                    ReasonForVisit reasonForVisit = new ReasonForVisit
                    {
                        PatientId = patient.Id,
                        Reason = "Filling"
                    };
                    reasonForVisits.Add(reasonForVisit);
                }
                if (yourHouseholdVM.Extraction)
                {
                    ReasonForVisit reasonForVisit = new ReasonForVisit
                    {
                        PatientId = patient.Id,
                        Reason = "Extraction"
                    };
                    reasonForVisits.Add(reasonForVisit);
                }
                _context.ReasonsForVisit.AddRange(reasonForVisits);
                _context.SaveChanges();




                List<HeardAbout> heardAbouts = new List<HeardAbout>();
                if (yourHouseholdVM.FamilyMemberFriend)
                {
                    HeardAbout heardAbout = new HeardAbout
                    {
                        PatientId = patient.Id,
                        HeardAboutHow = "FamilyMemberFriend"
                    };
                    heardAbouts.Add(heardAbout);
                }
                if (yourHouseholdVM.Television)
                {
                    HeardAbout heardAbout = new HeardAbout
                    {
                        PatientId = patient.Id,
                        HeardAboutHow = "Television"
                    };
                    heardAbouts.Add(heardAbout);
                }
                if (yourHouseholdVM.Radio)
                {
                    HeardAbout heardAbout = new HeardAbout
                    {
                        PatientId = patient.Id,
                        HeardAboutHow = "Radio"
                    };
                    heardAbouts.Add(heardAbout);
                }
                if (yourHouseholdVM.Newspaper)
                {
                    HeardAbout heardAbout = new HeardAbout
                    {
                        PatientId = patient.Id,
                        HeardAboutHow = "Newspaper"
                    };
                    heardAbouts.Add(heardAbout);
                }
                if (yourHouseholdVM.Internet)
                {
                    HeardAbout heardAbout = new HeardAbout
                    {
                        PatientId = patient.Id,
                        HeardAboutHow = "Internet"
                    };
                    heardAbouts.Add(heardAbout);
                }
                if (yourHouseholdVM.DoctorOffice)
                {
                    HeardAbout heardAbout = new HeardAbout
                    {
                        PatientId = patient.Id,
                        HeardAboutHow = "DoctorOffice"
                    };
                    heardAbouts.Add(heardAbout);
                }
                if (yourHouseholdVM.CenterClinic)
                {
                    HeardAbout heardAbout = new HeardAbout
                    {
                        PatientId = patient.Id,
                        HeardAboutHow = "CenterClinic"
                    };
                    heardAbouts.Add(heardAbout);
                }
                if (yourHouseholdVM.Hospital)
                {
                    HeardAbout heardAbout = new HeardAbout
                    {
                        PatientId = patient.Id,
                        HeardAboutHow = "Hospital"
                    };
                    heardAbouts.Add(heardAbout);
                }
                if (yourHouseholdVM.Religious)
                {
                    HeardAbout heardAbout = new HeardAbout
                    {
                        PatientId = patient.Id,
                        HeardAboutHow = "Religious"
                    };
                    heardAbouts.Add(heardAbout);
                }
                if (yourHouseholdVM.Work)
                {
                    HeardAbout heardAbout = new HeardAbout
                    {
                        PatientId = patient.Id,
                        HeardAboutHow = "Work"
                    };
                    heardAbouts.Add(heardAbout);
                }
                if (yourHouseholdVM.Other)
                {
                    HeardAbout heardAbout = new HeardAbout
                    {
                        PatientId = patient.Id,
                        HeardAboutHow = yourHouseholdVM.OtherAnswer
                    };
                    heardAbouts.Add(heardAbout);
                }

                _context.HeardAbouts.AddRange(heardAbouts);
                _context.SaveChanges();
                List<OtherReasonsForVisit> otherReasonsForVisits = new List<OtherReasonsForVisit>();
                if (yourHouseholdVM.NoReason)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "NoReason"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.DentalEmer)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "DentalEmer"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.CantAfford)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "CantAfford)"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.DontWantToSpend)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "DontWantToSpend"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.NoDental)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "NoDental"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.NoApp)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "NoApp"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.NoTimeOff)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "NoTimeOff"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.TooFar)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "TooFar"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.NotOpen)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "NotOpen"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.TooBusy)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "TooBusy"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.NoTransport)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "NoTransport"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.DontKnow)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "DontKnow"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.ToldToCome)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = "ToldToCome"
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                if (yourHouseholdVM.Other2)
                {
                    OtherReasonsForVisit otherReasonsForVisit = new OtherReasonsForVisit
                    {
                        PatientId = patient.Id,
                        OtherReason = yourHouseholdVM.OtherAnswer2
                    };
                    otherReasonsForVisits.Add(otherReasonsForVisit);
                }
                _context.OtherReasonsForVisit.AddRange(otherReasonsForVisits);
                _context.SaveChanges();
                List<DentalOfficesVisited> dentalOfficesVisiteds = new List<DentalOfficesVisited>();
                if (yourHouseholdVM.DentistOffice)
                {
                    DentalOfficesVisited dentalOfficesVisited = new DentalOfficesVisited
                    {
                        PatientId = patient.Id,
                        OfficeName = "Dentist’s office"
                    };
                    dentalOfficesVisiteds.Add(dentalOfficesVisited);
                }
                if (yourHouseholdVM.TallMemHos)
                {
                    DentalOfficesVisited dentalOfficesVisited = new DentalOfficesVisited
                    {
                        PatientId = patient.Id,
                        OfficeName = "Tallahassee Memorial Hospital emergency room"
                    };
                    dentalOfficesVisiteds.Add(dentalOfficesVisited);
                }
                if (yourHouseholdVM.CapRegMedCenter)
                {
                    DentalOfficesVisited dentalOfficesVisited = new DentalOfficesVisited
                    {
                        PatientId = patient.Id,
                        OfficeName = "Capital Regional Medical Center emergency room"
                    };
                    dentalOfficesVisiteds.Add(dentalOfficesVisited);
                }
                if (yourHouseholdVM.BondComHealth)
                {
                    DentalOfficesVisited dentalOfficesVisited = new DentalOfficesVisited
                    {
                        PatientId = patient.Id,
                        OfficeName = "Bond Community Health Center"
                    };
                    dentalOfficesVisiteds.Add(dentalOfficesVisited);
                }
                if (yourHouseholdVM.CarePoint)
                {
                    DentalOfficesVisited dentalOfficesVisited = new DentalOfficesVisited
                    {
                        PatientId = patient.Id,
                        OfficeName = "Care Point Health & Wellness"
                    };
                    dentalOfficesVisiteds.Add(dentalOfficesVisited);
                }
                if (yourHouseholdVM.KearneyCenter)
                {
                    DentalOfficesVisited dentalOfficesVisited = new DentalOfficesVisited
                    {
                        PatientId = patient.Id,
                        OfficeName = "The Kearney Center"
                    };
                    dentalOfficesVisiteds.Add(dentalOfficesVisited);
                }
                if (yourHouseholdVM.LeonCounty)
                {
                    DentalOfficesVisited dentalOfficesVisited = new DentalOfficesVisited
                    {
                        PatientId = patient.Id,
                        OfficeName = "Leon County Health Department"
                    };
                    dentalOfficesVisiteds.Add(dentalOfficesVisited);
                }
                if (yourHouseholdVM.NeighborhoodMedCenter)
                {
                    DentalOfficesVisited dentalOfficesVisited = new DentalOfficesVisited
                    {
                        PatientId = patient.Id,
                        OfficeName = "Neighborhood Medical Center"
                    };
                    dentalOfficesVisiteds.Add(dentalOfficesVisited);
                }
                if (yourHouseholdVM.TallComDental)
                {
                    DentalOfficesVisited dentalOfficesVisited = new DentalOfficesVisited
                    {
                        PatientId = patient.Id,
                        OfficeName = "Tallahassee Community College Dental Hygiene Clinic"
                    };
                    dentalOfficesVisiteds.Add(dentalOfficesVisited);
                }
                if (yourHouseholdVM.NoLocations)
                {
                    DentalOfficesVisited dentalOfficesVisited = new DentalOfficesVisited
                    {
                        PatientId = patient.Id,
                        OfficeName = "None of these locations visited"
                    };
                    dentalOfficesVisiteds.Add(dentalOfficesVisited);
                }
                _context.DentalOfficesVisited.AddRange(dentalOfficesVisiteds);
                _context.SaveChanges();

                List<Tobacco> tobaccos = new List<Tobacco>();
                if (yourHouseholdVM.Cigarettes)
                {
                    Tobacco tobacco = new Tobacco
                    {
                        PatientId = patient.Id,
                        Type = "Cigarettes"
                    };
                    tobaccos.Add(tobacco);
                }
                if (yourHouseholdVM.Pipes)
                {
                    Tobacco tobacco = new Tobacco
                    {
                        PatientId = patient.Id,
                        Type = "Pipes"
                    };
                    tobaccos.Add(tobacco);
                }
                if (yourHouseholdVM.Cigars)
                {
                    Tobacco tobacco = new Tobacco
                    {
                        PatientId = patient.Id,
                        Type = "Cigars"
                    };
                    tobaccos.Add(tobacco);
                }
                if (yourHouseholdVM.Hookahs)
                {
                    Tobacco tobacco = new Tobacco
                    {
                        PatientId = patient.Id,
                        Type = "Hookahs"
                    };
                    tobaccos.Add(tobacco);
                }
                if (yourHouseholdVM.Ecigarettes)
                {
                    Tobacco tobacco = new Tobacco
                    {
                        PatientId = patient.Id,
                        Type = "Ecigarettes"
                    };
                    tobaccos.Add(tobacco);
                }
                if (yourHouseholdVM.ChewingTobacco)
                {
                    Tobacco tobacco = new Tobacco
                    {
                        PatientId = patient.Id,
                        Type = "ChewingTobacco"
                    };
                    tobaccos.Add(tobacco);
                }
                if (yourHouseholdVM.Snuff)
                {
                    Tobacco tobacco = new Tobacco
                    {
                        PatientId = patient.Id,
                        Type = "Snuff"
                    };
                    tobaccos.Add(tobacco);
                }
                if (yourHouseholdVM.Snus)
                {
                    Tobacco tobacco = new Tobacco
                    {
                        PatientId = patient.Id,
                        Type = "Snus"
                    };
                    tobaccos.Add(tobacco);
                }
                if (yourHouseholdVM.Dissolvables)
                {
                    Tobacco tobacco = new Tobacco
                    {
                        PatientId = patient.Id,
                        Type = "Dissolvables"
                    };
                    tobaccos.Add(tobacco);
                }
                if (yourHouseholdVM.NoSmoking)
                {
                    Tobacco tobacco = new Tobacco
                    {
                        PatientId = patient.Id,
                        Type = "Patient Does Not Smoke"
                    };
                    tobaccos.Add(tobacco);
                }
                _context.Tobacco.AddRange(tobaccos);
                _context.SaveChanges();
                List<KindOfHealthcare> kindOfHealthcares = new List<KindOfHealthcare>();
                if (yourHouseholdVM.InsFromEmp)
                {
                    KindOfHealthcare kindOfHealthcare = new KindOfHealthcare
                    {
                        PatientId = patient.Id,
                        Type = "Insurance from employer"
                    };
                    kindOfHealthcares.Add(kindOfHealthcare);
                }
                if (yourHouseholdVM.InsFromComp)
                {
                    KindOfHealthcare kindOfHealthcare = new KindOfHealthcare
                    {
                        PatientId = patient.Id,
                        Type = "Insurance purchased directly from an insurance company"
                    };
                    kindOfHealthcares.Add(kindOfHealthcare);
                }
                if (yourHouseholdVM.Medicare)
                {
                    KindOfHealthcare kindOfHealthcare = new KindOfHealthcare
                    {
                        PatientId = patient.Id,
                        Type = "Medicare"
                    };
                    kindOfHealthcares.Add(kindOfHealthcare);
                }
                if (yourHouseholdVM.Medicade)
                {
                    KindOfHealthcare kindOfHealthcare = new KindOfHealthcare
                    {
                        PatientId = patient.Id,
                        Type = "Medicade"
                    };
                    kindOfHealthcares.Add(kindOfHealthcare);
                }
                if (yourHouseholdVM.InsFromHcGov)
                {
                    KindOfHealthcare kindOfHealthcare = new KindOfHealthcare
                    {
                        PatientId = patient.Id,
                        Type = "Insurance purchased through Healthcare.gov"
                    };
                    kindOfHealthcares.Add(kindOfHealthcare);
                }
                if (yourHouseholdVM.Military)
                {
                    KindOfHealthcare kindOfHealthcare = new KindOfHealthcare
                    {
                        PatientId = patient.Id,
                        Type = "Military"
                    };
                    kindOfHealthcares.Add(kindOfHealthcare);
                }
                if (yourHouseholdVM.AnotherKind)
                {
                    KindOfHealthcare kindOfHealthcare = new KindOfHealthcare
                    {
                        PatientId = patient.Id,
                        Type = "Another type of health insurance or health coverage"
                    };
                    kindOfHealthcares.Add(kindOfHealthcare);
                }
                if (yourHouseholdVM.NoIns)
                {
                    KindOfHealthcare kindOfHealthcare = new KindOfHealthcare
                    {
                        PatientId = patient.Id,
                        Type = "No Insurance"
                    };
                    kindOfHealthcares.Add(kindOfHealthcare);
                }
                _context.KindOfHealthcare.AddRange(kindOfHealthcares);
                _context.SaveChanges();
                List<PatientRace> patientRaces = new List<PatientRace>();
                if (yourHouseholdVM.White)
                {
                    PatientRace patientRace = new PatientRace
                    {
                        PatientId = patient.Id,
                        Race = "White"
                    };
                    patientRaces.Add(patientRace);
                }
                if (yourHouseholdVM.Black)
                {
                    PatientRace patientRace = new PatientRace
                    {
                        PatientId = patient.Id,
                        Race = "Black"
                    };
                    patientRaces.Add(patientRace);
                }
                if (yourHouseholdVM.Asian)
                {
                    PatientRace patientRace = new PatientRace
                    {
                        PatientId = patient.Id,
                        Race = "Asian"
                    };
                    patientRaces.Add(patientRace);
                }
                if (yourHouseholdVM.PacificIslander)
                {
                    PatientRace patientRace = new PatientRace
                    {
                        PatientId = patient.Id,
                        Race = "PacificIslander"
                    };
                    patientRaces.Add(patientRace);
                }
                if (yourHouseholdVM.AmericanIndian)
                {
                    PatientRace patientRace = new PatientRace
                    {
                        PatientId = patient.Id,
                        Race = "AmericanIndian"
                    };
                    patientRaces.Add(patientRace);
                }
                if (yourHouseholdVM.Other3)
                {
                    PatientRace patientRace = new PatientRace
                    {
                        PatientId = patient.Id,
                        Race = "Other"
                    };
                    patientRaces.Add(patientRace);
                }
                _context.PatientRace.AddRange(patientRaces);
                _context.SaveChanges();
                return RedirectToAction(nameof(Confirmation), new ConfirmationVM { PatientID = patient.UniquePatientId });
            }
            return View(yourHouseholdVM);
        }

        // POST: VisitInformations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

    }
}
