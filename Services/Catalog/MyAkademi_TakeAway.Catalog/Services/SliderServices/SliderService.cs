using AutoMapper;
using MongoDB.Driver;
using MyAkademi_TakeAway.Catalog.Dtos.FeatureDtos;
using MyAkademi_TakeAway.Catalog.Dtos.SliderDtos;
using MyAkademi_TakeAway.Catalog.Entities;
using MyAkademi_TakeAway.Catalog.Settings;

namespace MyAkademi_TakeAway.Catalog.Services.SliderServices
{
    public class SliderService : ISliderServices
    {
        private readonly IMongoCollection<Slider> _sliderCollection;
        private readonly IMapper _mapper;

        public SliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _sliderCollection = database.GetCollection<Slider>(_databaseSettings.FeatureCollectionName);
            _mapper = mapper;
        }

        public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            await _sliderCollection.InsertOneAsync(value);
        }

        public async Task DeleteSliderAsync(string id)
        {
            await _sliderCollection.DeleteOneAsync(x => x.SliderID == id);
        }

        public async Task<List<ResultSliderDto>> GetAllSliderAsync()
        {
            var values = await _sliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSliderDto>>(values);
        }

        public async Task<GetByIdSliderDto> GetByIdSliderAsync(string id)
        {
            var values = await _sliderCollection.Find(x => x.SliderID == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSliderDto>(values);
        }

        public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        {
            var values = _mapper.Map<Slider>(updateSliderDto);
            await _sliderCollection.FindOneAndReplaceAsync(x => x.SliderID == updateSliderDto.SliderID, values);
        }
    }
}


