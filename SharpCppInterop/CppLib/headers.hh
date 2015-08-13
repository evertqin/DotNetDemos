#ifndef CPPLIB_HEADERS_HH
#define CPPLIB_HEADERS_HH

struct OneDimRetArray
{
	double* content;
	int size;
};

typedef struct OneDimRetArray OneDimRetArray_t;

extern "C"
{
	__declspec(dllexport) void get_simple_type(int num);
	__declspec(dllexport) double return_simple_type(double num);

	__declspec(dllexport) OneDimRetArray_t* make_1d_array(const double* input, int size);
	__declspec(dllexport) int release_one_dim(OneDimRetArray_t* toFree);
}

#endif

