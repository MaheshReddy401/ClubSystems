using ClubSystemsTest.Models.Dto;
using ClubSystemsTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClubSystemsDemo.Controllers
{
    public class MembershipDetailsController : Controller
    {
        protected ResponseDto _response;
        private IMembershipRepository _membershipRepository;

        public MembershipDetailsController(IMembershipRepository membershipRepository)
        {
            this._response = new ResponseDto();
            _membershipRepository = membershipRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<MembershipDetailsDto> membershipDetailsDtoList = await _membershipRepository.GetMembershipDetails();
                _response.Result = membershipDetailsDtoList;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return View(_response.Result);
        }

        [HttpGet]
        public async Task<object> Details(int id)
        {
            try
            {
                MembershipDetailsDto membershipDetailsDto = await _membershipRepository.GetMembershipDetailsById(id);
                _response.Result = membershipDetailsDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return View(_response.Result);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Create([Bind("MemebershipID,Type,AccountBalance,PersonID")] MembershipDetailsDto membershipDetailsDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MembershipDetailsDto model = await _membershipRepository.CreateUpdateMembershipDetails(membershipDetailsDto);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return View(membershipDetailsDto);
        }

        public async Task<ActionResult> Edit(int id)
        {

            try
            {
                MembershipDetailsDto membershipDetailsDto = await _membershipRepository.GetMembershipDetailsById(id); ;
                _response.Result = membershipDetailsDto;
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }

            return View(_response.Result);
        }

        [HttpPost]
        public async Task<ActionResult> Edit([Bind("MemebershipID,Type,AccountBalance,PersonID")] MembershipDetailsDto membershipDetailsDto)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    MembershipDetailsDto model = await _membershipRepository.CreateUpdateMembershipDetails(membershipDetailsDto);
                    _response.Result = model;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag["Error"] = "PersonId and Type should be unique";
                }
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }

            return View(_response.Result);
        }
        public async Task<IActionResult> OverDrawn()
        {
            try
            {
                IEnumerable<MembershipDetailsDto> membershipDetailsDtoList = await _membershipRepository.GetMembershipDetails();
                _response.Result = membershipDetailsDtoList.Where(x => x.AccountBalance < 0).ToList();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return View(_response.Result);
        }

    }
}
