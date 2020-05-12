        .text

# int MaxInArray(const int* array, int count);
        .globl  MaxInArray
MaxInArray:
        # пролог
        pushq   %rbp
        movq    %rsp, %rbp
        # запись в стек адреса первого элемента массива -24(%rbp)
        movq    %rdi, -24(%rbp)                 # -24(%rbp) <- array
        # запись в стек кол-ва элементов -28(%rbp)
        movl    %esi, -28(%rbp)                 # -28(%rbp) <- count
        # максимум (в начале первый элемент массива) -4(%rbp)
        movq    -24(%rbp), %rax                 # %rax <- array
        movl    (%rax), %eax                    # %eax <- (%rax)[0]
        movl    %eax, -4(%rbp)                  # -4(%rbp) <- %eax
        # итератор -8(%rbp)
        movl    $0, -8(%rbp)                    # -8(%rbp) <- 0
Loop1_Start:
        # сравнение итератора с кол-вом элементов
        movl    -8(%rbp), %eax                  # %eax <- -8(%rbp)
        cmpl    -28(%rbp), %eax                 # compare -28(%rbp), %eax
        jge     Loop1_End                       # if greater or equal go to Loop1_End
        # вычысление адреса
        movl    -8(%rbp), %eax                  # %eax <- -8(%rbp)
        cltq                                    # %rax <- %eax
        leaq    0(,%rax,4), %rdx                # %rdx <- %rax * 4
        movq    -24(%rbp), %rax                 # %rax <- -24(%rbp)
        addq    %rdx, %rax                      # %rax += %rdx
        movl    (%rax), %eax                    # %eax <- *(%rax)
        cmpl    %eax, -4(%rbp)                  # compare %eax, -4(%rbp)
        jge     Loop1_Continue
        movl    -8(%rbp), %eax
        cltq
        leaq    0(,%rax,4), %rdx
        movq    -24(%rbp), %rax
        addq    %rdx, %rax
        movl    (%rax), %eax
        movl    %eax, -4(%rbp)
Loop1_Continue:
        addl    $1, -8(%rbp)
        jmp     Loop1_Start
Loop1_End:
        movl    -4(%rbp), %eax
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
