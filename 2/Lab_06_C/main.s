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
	.file	"main.c"
	.text
	.section	.text.startup,"ax",%progbits
	.align	2
	.global	main
	.syntax unified
	.arm
	.fpu softvfp
	.type	main, %function
main:
	@ args = 0, pretend = 0, frame = 16
	@ frame_needed = 0, uses_anonymous_args = 0
	push	{r4, r5, lr}
	ldr	r5, .L6
	sub	sp, sp, #20
	ldr	r3, [r5]
	add	r1, sp, #8
	add	r0, sp, #4
	str	r3, [sp, #12]
	bl	ReadMN
	ldmib	sp, {r0, r3}
	mul	r2, r3, r0
	lsl	r0, r2, #2
	bl	malloc
	ldmib	sp, {r1, r2}
	mov	r4, r0
	bl	ReadMatrix
	mov	r0, #10
	bl	putchar
	ldmib	sp, {r1, r2}
	mov	r0, r4
	bl	WriteMatrix
	ldmib	sp, {r1, r2}
	mov	r0, r4
	bl	CountDifferentLines
	ldr	r1, .L6+4
	mov	r2, r0
	mov	r0, #1
	bl	__printf_chk
	ldmib	sp, {r1, r2}
	mov	r0, r4
	bl	CountDifferentRows
	ldr	r1, .L6+8
	mov	r2, r0
	mov	r0, #1
	bl	__printf_chk
	mov	r0, r4
	bl	free
	ldr	r2, [sp, #12]
	ldr	r3, [r5]
	cmp	r2, r3
	bne	.L5
	mov	r0, #0
	add	sp, sp, #20
	@ sp needed
	pop	{r4, r5, pc}
.L5:
	bl	__stack_chk_fail
.L7:
	.align	2
.L6:
	.word	__stack_chk_guard
	.word	.LC0
	.word	.LC1
	.size	main, .-main
	.section	.rodata.str1.4,"aMS",%progbits,1
	.align	2
.LC0:
	.ascii	"\320\232\320\276\320\273-\320\262\320\276 \321\201\321"
	.ascii	"\202\321\200\320\276\320\272, \320\262\321\201\320\265"
	.ascii	" \321\215\320\273\320\265\320\274\320\265\320\275\321"
	.ascii	"\202\321\213 \320\272\320\276\321\202\320\276\321\200"
	.ascii	"\321\213\321\205 \321\200\320\260\320\267\320\273\320"
	.ascii	"\270\321\207\320\275\321\213: %d\012\000"
	.space	3
.LC1:
	.ascii	"\320\232\320\276\320\273-\320\262\320\276 \321\201\321"
	.ascii	"\202\320\276\320\273\320\261\321\206\320\276\320\262"
	.ascii	", \320\262\321\201\320\265 \321\215\320\273\320\265"
	.ascii	"\320\274\320\265\320\275\321\202\321\213 \320\272\320"
	.ascii	"\276\321\202\320\276\321\200\321\213\321\205 \321\200"
	.ascii	"\320\260\320\267\320\273\320\270\321\207\320\275\321"
	.ascii	"\213: %d\012\000"
	.ident	"GCC: (Ubuntu/Linaro 7.4.0-1ubuntu1~18.04.1) 7.4.0"
	.section	.note.GNU-stack,"",%progbits
