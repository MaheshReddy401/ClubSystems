using ClubSystemsTest.Models.Dto;
using ClubSystemsTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClubSystemsTest.Controllers
{

    public class UserDetailsController : Controller
    {
        protected ResponseDto _response;
        private IUserRepository _userRepository;

        public UserDetailsController(IUserRepository userRepository)
        {
            this._response = new ResponseDto();
            _userRepository = userRepository;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                IEnumerable<UserDetailsDto> userDetailsDtoList = await _userRepository.GetUserDetails();
                _response.Result = userDetailsDtoList;
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
                UserDetailsDto userDetailsDto = await _userRepository.GetUserDetailsById(id);
                _response.Result = userDetailsDto;
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
        public async Task<ActionResult> Create([Bind("PersonID,Forename,Surname,EmailAddress")] UserDetailsDto userDetailsDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDetailsDto model = await _userRepository.CreateUpdateUserDetails(userDetailsDto);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return View(userDetailsDto);
        }

        public async Task<ActionResult> Edit(int id)
        {

            try
            {
                UserDetailsDto model = await _userRepository.GetUserDetailsById(id);
                _response.Result = model;
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
        public async Task<ActionResult> Edit([Bind("PersonID,Forename,Surname,EmailAddress")] UserDetailsDto userDetailsDto)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    UserDetailsDto model = await _userRepository.CreateUpdateUserDetails(userDetailsDto);
                    _response.Result = model;
                    return RedirectToAction("Index");
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
    }
}
