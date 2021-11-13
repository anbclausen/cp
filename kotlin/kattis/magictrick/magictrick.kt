fun main() {
    val inp = readLine()!!.toString().toCharArray()
    val set = inp.toSet()

    if (inp.size == set.size)
        println("1")
    else
        println("0")
}