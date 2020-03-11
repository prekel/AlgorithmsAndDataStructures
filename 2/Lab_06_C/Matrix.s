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
	.file	"Matrix.c"
	.text
	.align	2
	.global	CheckAllDifferent
	.syntax unified
	.arm
	.fpu softvfp
	.type	CheckAllDifferent, %function
CheckAllDifferent:
	@ args = 0, pretend = 0, frame = 0
	@ frame_needed = 0, uses_anonymous_args = 0
	push	{r4, r5, r6, lr}
	mul	r6, r1, r2
	cmp	r6, #0
	ble	.L7
	mov	r4, r1
	rsb	r5, r1, r1, lsl #30
	cmp	r6, r4
	add	r5, r0, r5, lsl #2
	mov	r3, r4
	ble	.L7
.L12:
	ldr	lr, [r5, r4, lsl #2]
	ldr	ip, [r0, r4, lsl #2]
	cmp	lr, ip
	bne	.L3
	b	.L9
.L4:
	ldr	ip, [r0, r3, lsl #2]
	cmp	ip, lr
	beq	.L9
.L3:
	add	r3, r3, r1
	cmp	r6, r3
	bgt	.L4
	add	r4, r4, r1
	cmp	r6, r4
	mov	r3, r4
	bgt	.L12
.L7:
	mov	r0, #1
	pop	{r4, r5, r6, pc}
.L9:
	mov	r0, #0
	pop	{r4, r5, r6, pc}
	.size	CheckAllDifferent, .-CheckAllDifferent
	.align	2
	.global	CountDifferentLines
	.syntax unified
	.arm
	.fpu softvfp
	.type	CountDifferentLines, %function
CountDifferentLines:
	@ args = 0, pretend = 0, frame = 0
	@ frame_needed = 0, uses_anonymous_args = 0
	cmp	r1, #0
	ble	.L21
	push	{r4, r5, r6, r7, r8, r9, lr}
	mov	r8, #0
	cmp	r2, #0
	mov	r7, r0
	lsl	r9, r2, #2
	mov	r0, r8
	ble	.L15
.L28:
	mov	r6, r7
	mov	r5, #0
.L19:
	add	r5, r5, #1
	cmp	r2, r5
	beq	.L15
	ldr	r4, [r6]
	ldr	r3, [r6, #4]!
	cmp	r4, r3
	beq	.L16
	mov	ip, r6
	mov	r3, r5
.L17:
	add	r3, r3, #1
	cmp	r2, r3
	beq	.L19
	ldr	lr, [ip, #4]!
	cmp	lr, r4
	bne	.L17
.L16:
	add	r8, r8, #1
	cmp	r1, r8
	add	r7, r7, r9
	popeq	{r4, r5, r6, r7, r8, r9, pc}
	cmp	r2, #0
	bgt	.L28
.L15:
	add	r0, r0, #1
	b	.L16
.L21:
	mov	r0, #0
	bx	lr
	.size	CountDifferentLines, .-CountDifferentLines
	.align	2
	.global	CountDifferentRows
	.syntax unified
	.arm
	.fpu softvfp
	.type	CountDifferentRows, %function
CountDifferentRows:
	@ args = 0, pretend = 0, frame = 0
	@ frame_needed = 0, uses_anonymous_args = 0
	cmp	r2, #0
	ble	.L37
	push	{r4, r5, r6, r7, r8, lr}
	mov	r7, r0
	mov	r0, #0
	mul	ip, r1, r2
	rsb	r6, r2, r2, lsl #30
	add	r6, r7, r6, lsl #2
	lsl	r8, r2, #2
.L36:
	cmp	ip, #0
	add	r4, r6, r8
	ble	.L31
	mov	r5, r2
	cmp	ip, r5
	mov	r3, r5
	ble	.L31
.L44:
	ldr	lr, [r6, r5, lsl #2]
	ldr	r1, [r4, r5, lsl #2]
	cmp	lr, r1
	bne	.L33
	b	.L32
.L34:
	ldr	r1, [r4, r3, lsl #2]
	cmp	r1, lr
	beq	.L32
.L33:
	add	r3, r3, r2
	cmp	ip, r3
	bgt	.L34
	add	r5, r5, r2
	cmp	ip, r5
	mov	r3, r5
	bgt	.L44
.L31:
	add	r0, r0, #1
.L32:
	add	r6, r6, #4
	cmp	r6, r7
	bne	.L36
	pop	{r4, r5, r6, r7, r8, pc}
.L37:
	mov	r0, #0
	bx	lr
	.size	CountDifferentRows, .-CountDifferentRows
	.ident	"GCC: (Ubuntu/Linaro 7.4.0-1ubuntu1~18.04.1) 7.4.0"
	.section	.note.GNU-stack,"",%progbits
