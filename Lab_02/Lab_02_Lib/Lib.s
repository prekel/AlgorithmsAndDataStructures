        .text

# int MaxInArray(const int* array, int count);
        .globl  MaxInArray
MaxInArray:
        # пролог
        pushq   %rbp
        movq    %rsp, %rbp
        # запись в стек адреса первого элемента массива -24(%rbp)
        # он будет смещатся чтобы получить нужный элемент
        movq    %rdi, -24(%rbp)                 # -24(%rbp) <- array
        # запись в стек кол-ва элементов -28(%rbp)
        movl    %esi, -28(%rbp)                 # -28(%rbp) <- count
        # максимум (в начале первый элемент массива) -4(%rbp)
        movq    -24(%rbp), %rax                 # %rax <- array
        movl    (%rax), %eax                    # %eax <- (%rax)[0]
        movl    %eax, -4(%rbp)                  # -4(%rbp) <- %eax
        # номер текущего элемента -8(%rbp)
        movl    $0, -8(%rbp)                    # -8(%rbp) <- 0
Loop1_Start:
        # сравнение номера текущего элемента с кол-вом элементов
        # если номер текущего равен или больше, то конец цикла
        movl    -8(%rbp), %eax                  # %eax <- -8(%rbp)
        cmpl    -28(%rbp), %eax                 # compare -28(%rbp) <= %eax
        jge     Loop1_End                       # if greater or equal go to Loop1_End
        # запись текущего элемента в %eax
        movq    -24(%rbp), %rax                 # %rax <- -24(%rbp)
        movl    (%rax), %eax                    # %eax <- *(%rax)
        # сравнение текущего и максимального
        # если максимальный больше, цикл идёт с начала
        cmpl    %eax, -4(%rbp)                  # compare %eax <= -4(%rbp)
        jge     Loop1_Continue                  # if greater or equal to to Loop1_Continue
        # иначе максимальному присваивается текущий
        movl    %eax, -4(%rbp)                  # -4(%rbp) <- %eax
Loop1_Continue:
        # номер текущего увеличивается на 1
        addl    $1, -8(%rbp)                    # -8(%rbp) += 1
        # адрес текущего увеличивается на 4 (байта)
        movq    -24(%rbp), %rax                 # %rax <- -24(%rbp)
        addq    $4, %rax                        # %rax += 4
        movq    %rax, -24(%rbp)                 # -24(%rbp) <- %rax
        # цикл идёт с начала
        jmp     Loop1_Start
Loop1_End:
        # возврат значения
        # return -4(%rbp)
        movl    -4(%rbp), %eax                  # %eax <- -4(%rbp)
        # эпилог
        popq    %rbp
        ret

# double AverageInArray(const int* array, int count);
        .globl  AverageInArray
AverageInArray:
pushq   %rbp
        movq    %rsp, %rbp
        movq    %rdi, -24(%rbp)
        movl    %esi, -28(%rbp)
        pxor    %xmm0, %xmm0
        movsd   %xmm0, -8(%rbp)
        movl    $0, -12(%rbp)
.L8:
        movl    -12(%rbp), %eax
        cmpl    -28(%rbp), %eax
        jge     .L7
        movl    -12(%rbp), %eax
        cltq
        leaq    0(,%rax,4), %rdx
        movq    -24(%rbp), %rax
        addq    %rdx, %rax
        movl    (%rax), %eax
        pxor    %xmm0, %xmm0
        cvtsi2sdl       %eax, %xmm0
        movsd   -8(%rbp), %xmm1
        addsd   %xmm1, %xmm0
        movsd   %xmm0, -8(%rbp)
        addl    $1, -12(%rbp)
        jmp     .L8
.L7:
        pxor    %xmm1, %xmm1
        cvtsi2sdl       -28(%rbp), %xmm1
        movsd   -8(%rbp), %xmm0
        divsd   %xmm1, %xmm0
        movq    %xmm0, %rax
        movq    %rax, %xmm0
        popq    %rbp
        ret
