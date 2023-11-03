namespace ParkingLotTest
{
    using ParkingLot;
    using System.ComponentModel.DataAnnotations;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_a_parking_ticket_when_park_car_given_a_parking_lot()
        {
            //Given
            int capacity = 10;
            ParkingLot parkinglot = new ParkingLot(capacity);
            Car car = new Car();

            //When
            var ticket = parkinglot.park(car);

            //Then
            Assert.IsType<Ticket>(ticket);
        }

        [Fact]
        public void Should_return_the_parked_car_when_fetch_the_car_given_a_parking_lot_with_a_parked_car()
        {
            //Given
            int capacity = 10;
            ParkingLot parkinglot = new ParkingLot(capacity);
            Car car = new Car();
            var ticket = parkinglot.park(car);

            //When
            var result = parkinglot.fetch(ticket);

            //Then
            Assert.True(car == result);
        }

        [Fact]
        public void Should_return_the_right_car_with_each_ticket_when_fetch_the_car_twice_given_a_parking_lot_with_two_parked_car()
        {
            //Given
            int capacity = 10;
            ParkingLot parkinglot = new ParkingLot(capacity);
            Car car1 = new Car();
            Car car2 = new Car();
            var ticket1 = parkinglot.park(car1);
            var ticket2 = parkinglot.park(car2);

            //When
            var result1 = parkinglot.fetch(ticket1);
            var result2 = parkinglot.fetch(ticket1);

            //Then
            Assert.True(car1 == result1);
            Assert.True(car2 == result2);
        }

        [Fact]
        public void Should_return_nothing_when_fetch_the_car_given_a_parking_lot_and_a_wrong_parking_ticket()
        {
            //Given
            int capacity = 10;
            ParkingLot parkinglot = new ParkingLot(capacity);
            Car car = new Car();
            var ticket = parkinglot.park(car);
            var invalidTicket = new Ticket();

            //When
            var result = parkinglot.fetch(invalidTicket);

            //Then
            Assert.Null(result);
        }

        [Fact]
        public void Should_return_nothing_when_fetch_the_car_given_a_parking_lot_and_a_used_parking_ticket()
        {
            //Given
            int capacity = 10;
            ParkingLot parkinglot = new ParkingLot(capacity);
            Car car = new Car();
            var ticket = parkinglot.park(car);
            parkinglot.fetch(ticket);

            //When
            var result = parkinglot.fetch(ticket);

            //Then
            Assert.Null(result);
        }

        [Fact]
        public void Should_return_nothing_when_park_the_car_given_a_parking_without_any_position()
        {
            //Given
            int capacity = 1;
            ParkingLot parkinglot = new ParkingLot(capacity);
            Car car1 = new Car();
            Car car2 = new Car();
            parkinglot.park(car1);

            //When
            var result = parkinglot.park(car2);

            //Then
            Assert.Null(result);
        }
    }
}
