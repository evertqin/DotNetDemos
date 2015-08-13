#include "headers.hh"
#include <iostream>
#include <fstream>


void get_simple_type(int num) {
	std::cout << "Number: \"" << num << "\"" << std::endl;
}

double return_simple_type(double num) {
	return 4.9 * num;
}

OneDimRetArray_t * make_1d_array(const double * input, int size) {
	OneDimRetArray_t * result = new OneDimRetArray_t();
	result->content = new double[size * 2];
	result->size = size * 2;

	const double * p = input;
	for (int i = 0, j = 0; i < size; ++i) {
		result->content[j++] = *p;
		result->content[j++] = *p;
		p++;
	}
	return result;
}
int release_one_dim(OneDimRetArray_t * ptr_to_free) {
	if (ptr_to_free == NULL) {
		return -1;
	}

	if (ptr_to_free->content != NULL) {
		delete[] ptr_to_free->content;
		ptr_to_free->content = NULL;
	}

	delete ptr_to_free;
	ptr_to_free = NULL;
	return 0;
}



int main(int argc, char* argv[]) {
	std::cout << "In main" << std::endl;

	get_simple_type(6);

	int c;
	std::cin >> c;

	return 0;
}