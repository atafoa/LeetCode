using System.Threading;

public class Foo {
    private Semaphore s2;
    private Semaphore s3;

    public Foo() {
        s2 = new Semaphore(initialCount: 0, maximumCount: 1);
        s3 = new Semaphore(initialCount: 0, maximumCount: 1);
    }

    public void First(Action printFirst) {
        // printFirst() outputs "first". Do not change or remove this line.
        printFirst();

        s2.Release();
    }

    public void Second(Action printSecond) {
        s2.WaitOne();

        // printSecond() outputs "second". Do not change or remove this line.
        printSecond();

        s3.Release();
    }

    public void Third(Action printThird) {
        s3.WaitOne();

        // printThird() outputs "third". Do not change or remove this line.
        printThird();
    }
}