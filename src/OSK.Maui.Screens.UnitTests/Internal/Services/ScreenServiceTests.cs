using Moq;
using OSK.Maui.Screens.Exceptions;
using OSK.Maui.Screens.Internal.Services;
using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;
using OSK.Maui.Screens.UnitTests.Helpers;
using Xunit;

namespace OSK.Maui.Screens.UnitTests.Internal.Services
{
    public class ScreenServiceTests
    {
        #region Variables

        private readonly List<ScreenRouteDescriptor> _routeDescriptors;
        private readonly List<PopupDescriptor> _popupDescriptors;
        private readonly Mock<IServiceProvider> _mockServiceProvider;

        private readonly ScreenService _screenService;

        #endregion

        #region Constructors

        public ScreenServiceTests()
        {
            _routeDescriptors = [];
            _popupDescriptors = [];
            _mockServiceProvider = new Mock<IServiceProvider>();

            _screenService = new ScreenService(_routeDescriptors, _popupDescriptors, _mockServiceProvider.Object);
        }

        #endregion

        #region NavigateToScreenAsync

        [Fact]
        public async Task NavigateToScreenAsync_NullNavigation_ThrowsArgumentNullException()
        {
            // Arrange/Act/Assert
            await Assert.ThrowsAsync<ArgumentNullException>(() => _screenService.NavigateToScreenAsync(null!));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task NavigateToScreenAsync_InvalidRoute_ThrowsArgumentException(string? route)
        {
            // Arrange
            var exceptionType = route == null ? typeof(ArgumentNullException) : typeof(ArgumentException);

            // Act/Assert
            await Assert.ThrowsAsync(exceptionType, () => _screenService.NavigateToScreenAsync(new ScreenNavigation(route!)));
        }

        [Fact]
        public async Task NavigateToScreenAsync_NavigationWithNoMatchingRoute_ThrowsScreenNavigationException()
        {
            // Arrange/Act/Assert
            await Assert.ThrowsAsync<ScreenNavigationException>(() => _screenService.NavigateToScreenAsync(new ScreenNavigation("valid")));
        }

        [Theory]
        [InlineData("abc/def")]
        [InlineData("aBc/dEf")]
        public async Task NavigateToScreenAsync_ValidNavigationWithMatchingRoute_VariousSpelling_ReturnsSuccessfully(string route)
        {
            // Arrange
            _routeDescriptors.Add(new ScreenRouteDescriptor(route.ToLower(), typeof(IServiceCollection), typeof(IServiceCollection)));

            var mockScreen = new object();

            var mockNavigationHandler = new Mock<IScreenNavigationHandler>();
            mockNavigationHandler.Setup(m => m.NavigateToAsync(It.IsAny<ScreenRouteDescriptor>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockScreen);

            _mockServiceProvider.Setup(m => m.GetService(It.IsAny<Type>()))
                .Returns(mockNavigationHandler.Object);

            // Act
            var screen = await _screenService.NavigateToScreenAsync(new ScreenNavigation(route));
        
            // Assert
            Assert.Equal(mockScreen, screen);
        }

        #endregion

        #region ShowPopupAsync

        [Fact]
        public async Task ShowPopupAsync_PopupWithNoMatchingDescriptor_ThrowsScreenNavigationException()
        {
            // Arrange/Act/Assert
            await Assert.ThrowsAsync<ScreenPopupNavigationException>(() => _screenService.ShowPopupAsync(new PopupNavigation(typeof(int), parentPage: null)));
        }

        [Fact]
        public async Task ShowPopupAsync_PopupWithMatchingDescriptor_()
        {
            // Arrange
            _popupDescriptors.Add(new PopupDescriptor(typeof(IScreenPopup), typeof(IScreenPopup)));

            var mockScreenPopup = new Mock<IScreenPopup>();

            var mockPopupHandler = new TestPopupHandler(mockScreenPopup.Object);
            mockPopupHandler.CloseResult = 1;

            var mockPopupProvider = new Mock<IPopupProvider>();
            mockPopupProvider.Setup(m => m.GetPopupAsync(It.IsAny<PopupNavigation>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockPopupHandler);

            _mockServiceProvider.Setup(m => m.GetService(It.IsAny<Type>()))
                .Returns(mockPopupProvider.Object);

            // Act
            var popupAwaiter = await _screenService.ShowPopupAsync(new PopupNavigation(typeof(IScreenPopup), parentPage: null));
            var result = await popupAwaiter.WaitForCloseAsync();

            // Assert
            Assert.Equal(1, result);
            mockScreenPopup.VerifySet(m => m.PopupHandler = mockPopupHandler, Times.Once);
        }

        #endregion
    }
}
