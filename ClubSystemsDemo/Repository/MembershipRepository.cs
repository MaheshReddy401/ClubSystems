using AutoMapper;
using ClubSystemsTest.DbContexts;
using ClubSystemsTest.Models;
using ClubSystemsTest.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ClubSystemsTest.Repository
{
    public class MembershipRepository : IMembershipRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public MembershipRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MembershipDetailsDto>> GetMembershipDetails()
        {
            List<MembershipDetails> membershipDetailsList = await _db.MembershipDetails.Include(m => m.UserDetails).ToListAsync();
            return _mapper.Map<List<MembershipDetailsDto>>(membershipDetailsList);
        }

        public async Task<MembershipDetailsDto> GetMembershipDetailsById(int memebershipID)
        {
            MembershipDetails membershipDetails = await _db.MembershipDetails.Include(m => m.UserDetails).Where(x => x.MemebershipID == memebershipID).FirstOrDefaultAsync();
            return _mapper.Map<MembershipDetailsDto>(membershipDetails);
        }

        public async Task<MembershipDetailsDto> CreateUpdateMembershipDetails(MembershipDetailsDto membershipDetailsDto)
        {
            MembershipDetails membershipDetails = _mapper.Map<MembershipDetailsDto, MembershipDetails>(membershipDetailsDto);
            if (membershipDetails.PersonID > 0)
            {
                _db.MembershipDetails.Update(membershipDetails);
            }
            else
            {
                _db.MembershipDetails.Add(membershipDetails);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<MembershipDetails, MembershipDetailsDto>(membershipDetails);
        }
    }
}
