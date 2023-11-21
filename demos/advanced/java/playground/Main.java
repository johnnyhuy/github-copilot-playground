import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter the number of elements in the Fibonacci series:");
        int count = scanner.nextInt();

        int[] fibonacciSeries = calculateFibonacciSeries(count);
        for (int i = 0; i < fibonacciSeries.length; i++) {
            System.out.print(fibonacciSeries[i] + " ");
        }
    }

    private static int[] calculateFibonacciSeries(int count) {
        int[] series = new int[count];
        // Copilot suggestion starts here
        series[0] = 0;
        series[1] = 1;
        for (int i = 2; i < count; i++) {
            series[i] = series[i - 1] + series[i - 2];
        }
        // Copilot suggestion ends here
        return series;
    }
}
