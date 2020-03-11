	.arch armv5t
	.eabi_attribute 20, 1
	.eabi_attribute 21, 1
	.eabi_attribute 23, 3
	.eabi_attribute 24, 1
	.eabi_attribute 25, 1
	.eabi_attribute 26, 2
	.eabi_attribute 30, 2
	.eabi_attribute 34, 0
	.eabi_attribute 18, 4
	.file	"MatrixIO.c"
	.text
	.align	2
	.global	ReadMN
	.syntax unified
	.arm
	.fpu softvfp
	.type	ReadMN, %function
ReadMN:
	@ args = 0, pretend = 0, frame = 0
	@ frame_needed = 0, uses_anonymous_args = 0
	push	{r4, r5, r6, lr}
	mov	r4, r0
	mov	r5, r1
	mov	r0, #1
	ldr	r1, .L4
	bl	__printf_chk
	mov	r2, r5
	mov	r1, r4
	pop	{r4, r5, r6, lr}
	ldr	r0, .L4+4
	b	__isoc99_scanf
.L5:
	.align	2
.L4:
	.word	.LC0
	.word	.LC1
	.size	ReadMN, .-ReadMN
	.align	2
	.global	ReadMatrix
	.syntax unified
	.arm
	.fpu softvfp
	.type	ReadMatrix, %function
ReadMatrix:
	@ args = 0, pretend = 0, frame = 8
	@ frame_needed = 0, uses_anonymous_args = 0
	push	{r4, r5, r6, r7, r8, r9, r10, fp, lr}
	subs	fp, r1, #0
	sub	sp, sp, #12
	ble	.L6
	cmp	r2, #0
	ble	.L6
	mov	r7, r2
	mov	r10, r0
	mov	r6, #0
	lsl	r3, r2, #2
	ldr	r9, .L12
	ldr	r8, .L12+4
	str	r3, [sp, #4]
.L8:
	mov	r5, r10
	mov	r4, #0
.L9:
	mov	r0, #1
	mov	r3, r4
	mov	r2, r6
	mov	r1, r9
	add	r4, r4, r0
	bl	__printf_chk
	mov	r1, r5
	mov	r0, r8
	bl	__isoc99_scanf
	cmp	r7, r4
	add	r5, r5, #4
	bne	.L9
	add	r6, r6, #1
	ldr	r3, [sp, #4]
	cmp	fp, r6
	add	r10, r10, r3
	bne	.L8
.L6:
	add	sp, sp, #12
	@ sp needed
	pop	{r4, r5, r6, r7, r8, r9, r10, fp, pc}
.L13:
	.align	2
.L12:
	.word	.LC2
	.word	.LC3
	.size	ReadMatrix, .-ReadMatrix
	.align	2
	.global	WriteMatrix
	.syntax unified
	.arm
	.fpu softvfp
	.type	WriteMatrix, %function
WriteMatrix:
	@ args = 0, pretend = 0, frame = 0
	@ frame_needed = 0, uses_anonymous_args = 0
	push	{r4, r5, r6, r7, r8, r9, r10, lr}
	mov	r8, r1
	mov	r3, r2
	mov	r9, r2
	mov	r5, r0
	mov	r2, r1
	mov	r0, #1
	ldr	r1, .L22
	bl	__printf_chk
	cmp	r8, #0
	pople	{r4, r5, r6, r7, r8, r9, r10, pc}
	mov	r7, #0
	ldr	r6, .L22+4
	lsl	r10, r9, #2
.L16:
	cmp	r9, #0
	addle	r5, r5, r10
	ble	.L19
	mov	r4, r5
	add	r5, r5, r10
.L17:
	ldr	r2, [r4], #4
	mov	r1, r6
	mov	r0, #1
	bl	__printf_chk
	cmp	r4, r5
	bne	.L17
.L19:
	add	r7, r7, #1
	mov	r0, #10
	bl	putchar
	cmp	r8, r7
	bne	.L16
	pop	{r4, r5, r6, r7, r8, r9, r10, pc}
.L23:
	.align	2
.L22:
	.word	.LC4
	.word	.LC5
	.size	WriteMatrix, .-WriteMatrix
	.section	.rodata.str1.4,"aMS",%progbits,1
	.align	2
.LC0:
	.ascii	"\320\222\320\262\320\265\320\264\320\270\321\202\320"
	.ascii	"\265 M \320\270 N (\320\272\320\276\320\273-\320\262"
	.ascii	"\320\276 \321\201\321\202\321\200\320\276\320\272 \320"
	.ascii	"\270 \321\201\321\202\320\276\320\273\320\261\321\206"
	.ascii	"\320\276\320\262, a[M][N]): \000"
	.space	2
.LC1:
	.ascii	"%d%d\000"
	.space	3
.LC2:
	.ascii	"\320\222\320\262\320\265\320\264\320\270\321\202\320"
	.ascii	"\265 a[%d][%d]: \000"
	.space	1
.LC3:
	.ascii	"%d\000"
	.space	1
.LC4:
	.ascii	"\320\234\320\260\321\202\321\200\320\270\321\206\320"
	.ascii	"\260 a[%d][%d]:\012\000"
	.space	1
.LC5:
	.ascii	"%d \000"
	.ident	"GCC: (Ubuntu/Linaro 7.4.0-1ubuntu1~18.04.1) 7.4.0"
	.section	.note.GNU-stack,"",%progbits
