#include <iostream>
using namespace std;

void task_1()

int main() {
  
    int arr[10] = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    
    int sum = 0;  
    
   
    for (int i = 0; i < 10; i++) {
        sum += arr[i];  
    }
    
    
    cout << "Summ: " << sum << endl;
    
    return 0;
}

void task_2() {
    const int N = 5;  
    int arr[N];
    double sum = 0.0;
    
    
    cout << "Enter " << N << " number:" << endl;
    for (int i = 0; i < N; ++i) {
        cin >> arr[i];
        sum += arr[i];
    }
    
    
    cout << "Massiv: ";
    for (int i = 0; i < N; ++i) {
        cout << arr[i] << " ";
    }
    cout << endl;
    
    
    double average = sum / N;
    cout << "Arithmetic mean: " << average << endl;
    
    return 0;
}

void task_3() {
    int arr[] = {1, 0, -3, 0, 5, 0, 7};
    int size = sizeof(arr) / sizeof(arr[0]);  
    int count = 0;

    for (int i = 0; i < size; ++i) {
        if (arr[i] == 0) {
            ++count;
        }
    }

    cout << "Number of elements: " << count << endl;
    return 0;
}

void task_4() {
    int arr[] = {-3, 5, -1, 0, -7, 2, -4, 8, -9, 1};
    int count = 0;

    for (int num : arr) {
        if (num < 0) {
            count++;
        }
    }

    cout << "a set of minimal elements: " << count << endl;
    return 0;
}


void task_5() {
    int n;
    std::cout << "Enter the number of elements: ";
    std::cin >> n;

    int arr[n];
    std::cout << "Enter an array of elements ";
    for (int i = 0; i < n; ++i) {
        std::cin >> arr[i];
    }

   
    int min_value = arr[0];

   
    for (int i = 1; i < n; ++i) {
        if (arr[i] < min_value) {
            min_value = arr[i];  
        }
    }

    std::cout << Minimalniy element : " << min_value << std::endl;

    return 0;
}


void task_6() {
    int arr[] = {3, 7, 2, 9, 5};
    int n = sizeof(arr) / sizeof(arr[0]);

    int max_index = 0;  
    for (int i = 1; i < n; ++i) {
        if (arr[i] > arr[max_index]) {
            max_index = i;  
        }
    }

    std::cout << "The index of the maximum element: " << max_index << std::endl;
    return 0;
}

void task_7() {
    const int SIZE = 5;
    int arr[SIZE] = {1, 2, 3, 4, 5};

   
    for (int i = 0; i < SIZE; i++) {
        arr[i] *= 2;
    }

   
    cout << "Result: ";
    for (int i = 0; i < SIZE; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;

    return 0;
}

void task_8() {
    const int n = 5;  
    int arr[n] = {-3, 4, -1, 0, -7};

   
    for (int i = 0; i < n; i++) {
        if (arr[i] < 0) {
            arr[i] = 0; 
        }
    }

    
    cout << "Result: ";
    for (int i = 0; i < n; i++) {
        cout << arr[i] << " ";
    }
    cout << endl;

    return 0;
}

void task_9() {
    const int n = 5;
    int arr[n] = {10, 20, 30, 40, 50};
    int X;

    cout << "Enter number X: ";
    cin >> X;

    bool found = false;
    for (int i = 0; i < n; ++i) {
        if (arr[i] == X) {
            found = true;
            break;
        }
    }

    if (found) {
        cout << "Number " << X << " It occurs en masse" << endl;
    } else {
        cout << "Number " << X << " It does not occur en masse." << endl;
    }

    return 0;
}


void task_10() {
    int arr[] = {1, 2, 3, 4, 5};
    int size = sizeof(arr) / sizeof(arr[0]);

    for (int i = size - 1; i >= 0; i--) {
        cout << arr[i] << " ";
    }
    cout << endl;

    return 0;
}

int main()
{
    task_1();
    task_2();
    task_3();
    task_4();
    task_5();
    task_6();
    task_7();
    task_8();
    task_9();
    task_10();
    
    
    return 0;
}
