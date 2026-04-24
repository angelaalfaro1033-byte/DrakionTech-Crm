//using DrakionTech.Crm.Business.Services;
//using DrakionTech.Crm.Data.Entities;
//using DrakionTech.Crm.Data.Entities.Enums;
//using DrakionTech.Crm.Data.Repositories;
//using Moq;

//namespace DrakionTech.Crm.Tests.Services
//{
//    public class OpportunityServiceTests
//    {
//        private readonly Mock<IOpportunityRepository> _mockRepo;
//        private readonly OpportunityService _service;

//        public OpportunityServiceTests()
//        {
//            _mockRepo = new Mock<IOpportunityRepository>();
//            _service = new OpportunityService(_mockRepo.Object);
//        }

//        // Successful stage transition
//        [Fact]
//        public async Task ChangeStageAsync_Should_Update_When_Valid_Transition()
//        {
//            var opportunityId = int.Newint();
//            var entity = new Opportunity
//            {
//                Id = opportunityId,
//                Stage = OpportunityStage.New
//            };

//            _mockRepo.Setup(r => r.GetByIdAsync(opportunityId, It.IsAny<CancellationToken>()))
//                     .ReturnsAsync(entity);

//            var result = await _service.ChangeStageAsync(opportunityId, OpportunityStage.Qualified);

//            Assert.True(result.Success);
//            Assert.Equal(OpportunityStage.Qualified, entity.Stage);

//            _mockRepo.Verify(r => r.UpdateAsync(entity, It.IsAny<CancellationToken>()), Times.Once);
//        }

//        // Invalid retrograde transition
//        [Fact]
//        public async Task ChangeStageAsync_Should_Fail_When_Moving_Backwards()
//        {
//            var opportunityId = int.Newint();
//            var entity = new Opportunity
//            {
//                Id = opportunityId,
//                Stage = OpportunityStage.Proposal
//            };

//            _mockRepo
//                .Setup(r => r.GetByIdAsync(
//                    It.Is<int>(g => g == opportunityId),
//                    It.IsAny<CancellationToken>()))
//                .ReturnsAsync((Opportunity?)entity);

//            var result = await _service.ChangeStageAsync(opportunityId, OpportunityStage.Qualified);

//            Assert.False(result.Success);
//            Assert.Contains("cannot move backwards", result.ErrorMessage);

//            _mockRepo.Verify(r => r.UpdateAsync(It.IsAny<Opportunity>(), It.IsAny<CancellationToken>()), Times.Never);
//        }

//        // Cannot change stage of a closed opportunity
//        [Theory]
//        [InlineData(OpportunityStage.Won)]
//        [InlineData(OpportunityStage.Lost)]
//        public async Task ChangeStageAsync_Should_Fail_When_Opportunity_Is_Closed(OpportunityStage closedStage)
//        {
//            var opportunityId = int.Newint();
//            var entity = new Opportunity
//            {
//                Id = opportunityId,
//                Stage = closedStage
//            };

//            _mockRepo.Setup(r => r.GetByIdAsync(opportunityId, It.IsAny<CancellationToken>()))
//                     .ReturnsAsync(entity);

//            var result = await _service.ChangeStageAsync(opportunityId, OpportunityStage.Proposal);

//            Assert.False(result.Success);
//            Assert.Equal("Cannot change stage of a closed opportunity.", result.ErrorMessage);

//            _mockRepo.Verify(r => r.UpdateAsync(It.IsAny<Opportunity>(), It.IsAny<CancellationToken>()), Times.Never);
//        }

//        // Opportunity does not exist
//        [Fact]
//        public async Task ChangeStageAsync_Should_Fail_When_Opportunity_Not_Found()
//        {
//            var opportunityId = int.Newint();

//            _mockRepo.Setup(r => r.GetByIdAsync(opportunityId, It.IsAny<CancellationToken>()))
//                     .ReturnsAsync((Opportunity?)null);

//            var result = await _service.ChangeStageAsync(opportunityId, OpportunityStage.Qualified);

//            Assert.False(result.Success);
//            Assert.Equal("Opportunity not found", result.ErrorMessage);

//            _mockRepo.Verify(r => r.UpdateAsync(It.IsAny<Opportunity>(), It.IsAny<CancellationToken>()), Times.Never);
//        }
//    }
//}