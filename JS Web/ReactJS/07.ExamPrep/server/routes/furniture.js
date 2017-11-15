const express = require('express')
const authCheck = require('../middleware/auth-check')
const furnitureData = require('../data/furniture')

const router = new express.Router()

function validateFurnitureForm (payload) {
  const errors = {}
  let isFormValid = true
  let message = ''

  payload.year = parseInt(payload.year)
  payload.price = parseInt(payload.price)

  if (!payload || typeof payload.make !== 'string' || payload.make.length < 3) {
    isFormValid = false
    errors.make = 'Make must be more than 3 symbols.'
  }

  if (!payload || typeof payload.model !== 'string' || payload.model.length < 3) {
    isFormValid = false
    errors.model = 'Model must be more than 3 symbols.'
  }

  if (!payload || !payload.year || payload.year < 1950 || payload.year > 2050) {
    isFormValid = false
    errors.year = 'Year must be between 1950 and 2050.'
  }

  if (!payload || typeof payload.description !== 'string' || payload.description.length < 10) {
    isFormValid = false
    errors.description = 'Description must be more than 10 symbols.'
  }

  if (!payload || !payload.price || payload.price < 0) {
    isFormValid = false
    errors.price = 'Price must be a positive number.'
  }

  if (!payload || typeof payload.image !== 'string' || payload.image.length === 0) {
    isFormValid = false
    errors.image = 'Image URL is required.'
  }

  if (!isFormValid) {
    message = 'Check the form for errors.'
  }

  return {
    success: isFormValid,
    message,
    errors
  }
}

router.post('/create', authCheck, (req, res) => {
  const furniture = req.body
  furniture.createdBy = req.user.email

  const validationResult = validateFurnitureForm(furniture)
  if (!validationResult.success) {
    return res.status(200).json({
      success: false,
      message: validationResult.message,
      errors: validationResult.errors
    })
  }

  furnitureData.save(furniture)

  res.status(200).json({
    success: true,
    message: 'Furniture added successfuly.',
    furniture
  })
})

router.get('/all', (req, res) => {
  const page = parseInt(req.query.page) || 1
  const search = req.query.search

  const furniture = furnitureData.all(page, search)

  res.status(200).json(furniture)
})

router.get('/details/:id', authCheck, (req, res) => {
  const id = req.params.id

  const furniture = furnitureData.findById(id)

  if (!furniture) {
    return res.status(200).json({
      success: false,
      message: 'Entry does not exists!'
    })
  }

  let response = {
    id,
    make: furniture.make,
    model: furniture.model,
    year: furniture.year,
    description: furniture.description,
    price: furniture.price,
    image: furniture.image,
    createdOn: furniture.createdOn,
    likes: furniture.likes.length
  }

  if (furniture.material) {
    response.material = furniture.material
  }

  res.status(200).json(response)
})

router.post('/details/:id/reviews/create', authCheck, (req, res) => {
  const id = req.params.id
  const user = req.user.name

  const furniture = furnitureData.findById(id)

  if (!furniture) {
    return res.status(200).json({
      success: false,
      message: 'Furniture does not exists!'
    })
  }

  let rating = req.body.rating
  const comment = req.body.comment

  if (rating) {
    rating = parseInt(rating)
  }

  if (!rating || rating < 1 || rating > 5) {
    return res.status(200).json({
      success: false,
      message: 'Rating must be between 1 and 5.'
    })
  }

  furnitureData.addReview(id, rating, comment, user)

  res.status(200).json({
    success: true,
    message: 'Review added successfuly.',
    review: {
      id,
      rating,
      comment,
      user
    }
  })
})

router.post('/details/:id/like', authCheck, (req, res) => {
  const id = req.params.id
  const user = req.user.email

  const furniture = furnitureData.findById(id)

  if (!furniture) {
    return res.status(200).json({
      success: false,
      message: 'Furniture does not exists!'
    })
  }

  const result = furnitureData.like(id, user)

  if (!result) {
    return res.status(200).json({
      success: false,
      message: 'This user has already liked this entry!'
    })
  }

  return res.status(200).json({
    success: true,
    message: 'Thank you for your like!'
  })
})

router.get('/details/:id/reviews', authCheck, (req, res) => {
  const id = req.params.id

  const furniture = furnitureData.findById(id)

  if (!furniture) {
    return res.status(200).json({
      success: false,
      message: 'Furniture does not exists!'
    })
  }

  const response = furnitureData.allReviews(id)

  res.status(200).json(response)
})

router.get('/mine', authCheck, (req, res) => {
  const user = req.user.email

  const furniture = furnitureData.byUser(user)

  res.status(200).json(furniture)
})

router.post('/delete/:id', authCheck, (req, res) => {
  const id = req.params.id
  const user = req.user.email

  const furniture = furnitureData.findById(id)

  if (!furniture || furniture.createdBy !== user) {
    return res.status(200).json({
      success: false,
      message: 'Furniture does not exists!'
    })
  }

  furnitureData.delete(id)

  return res.status(200).json({
    success: true,
    message: 'Furniture deleted successfully!'
  })
})

module.exports = router
