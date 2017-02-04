using FluentAssertions;
using Xunit;

namespace ValueCopier.Tests
{
    public class ObjectExtensionTests
    {
        [Fact]
        public void AssignValuesToInt()
        {
            // Arrange
            var expectedResult = new TestClass1 { Property = 2 };

            var class1 = new TestClass1 { Property = 1 };
            var class2 = new TestClass1 { Property = 2 };

            // Act
            var result = ObjectExtension.Assign(class1, class2);

            // Assert
            result.ShouldBeEquivalentTo(expectedResult);
        }

        [Fact]
        public void AssignValuesToIntWithMultipleValues()
        {
            // Arrange
            var expectedResult = new TestClass1 { Property = 10 };

            var class1 = new TestClass1 { Property = 1 };
            var class2 = new TestClass1 { Property = 2 };
            var class3 = new TestClass1 { Property = -2 };
            var class4 = new TestClass1 { Property = 10 };

            // Act
            var result = ObjectExtension.Assign(class1, class2, class3, class4);

            // Assert
            result.ShouldBeEquivalentTo(expectedResult);
        }

        [Fact]
        public void AssignValuesToString()
        {
            // Arrange
            var expectedResult = new TestClass3 { Property = "Test" };

            var class1 = new TestClass3();
            var class2 = new TestClass3 { Property = "Test" };

            // Act
            var result = ObjectExtension.Assign(class1, class2);

            // Assert
            result.ShouldBeEquivalentTo(expectedResult);
        }

        [Fact]
        public void AssignValuesToReferenceTypeWithNullValues()
        {
            // Arrange
            var expectedResult = new TestClass4 { Property = new TestClass2 { PropertyB = 4 } };

            var class1 = new TestClass4 { Property = new TestClass2 { PropertyB = 4 } };
            var class2 = new TestClass4();

            // Act
            var result = ObjectExtension.Assign(class1, class2);

            // Assert
            result.ShouldBeEquivalentTo(expectedResult);
        }

        [Fact]
        public void AssignValuesToReferenceTypeWithNotNullValues()
        {
            // Arrange
            var expectedResult = new TestClass4 { Property = new TestClass2 { PropertyB = 10 } };

            var class1 = new TestClass4 { Property = new TestClass2 { PropertyB = 4 } };
            var class2 = new TestClass4 { Property = new TestClass2 { PropertyB = 10 } };

            // Act
            var result = ObjectExtension.Assign(class1, class2);

            // Assert
            result.ShouldBeEquivalentTo(expectedResult);
        }
    }
}
